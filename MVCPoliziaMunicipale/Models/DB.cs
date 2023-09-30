using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.WebSockets;

namespace MVCPoliziaMunicipale.Models
{
    public class DB
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
        public static SqlConnection conn = new SqlConnection(connectionString);

        public static void CreaTrasgressore(Trasgressore trasgressore)
        {
            try 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO ANAGRAFICA(Cognome, Nome, Indirizzo, Citta, Cap, CodiceFiscale)" +
                                  "VALUES(@Cognome, @Nome, @Indirizzo, @Citta, @Cap, @CodiceFiscale)";
                cmd.Parameters.AddWithValue("@Cognome", trasgressore.Cognome);
                cmd.Parameters.AddWithValue("@Nome", trasgressore.Nome);
                cmd.Parameters.AddWithValue("@Indirizzo", trasgressore.Indirizzo);
                cmd.Parameters.AddWithValue("@Citta", trasgressore.Citta);
                cmd.Parameters.AddWithValue("@Cap", trasgressore.Cap);
                cmd.Parameters.AddWithValue("@CodiceFiscale", trasgressore.CodiceFiscale);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {

            }
            finally { conn.Close(); }
        }
        public static List<Trasgressore> ListaTrasgressori()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ANAGRAFICA", conn);
            SqlDataReader sqldatareader;
            conn.Open();
            List<Trasgressore>TrasgressoriList = new List<Trasgressore>();
            sqldatareader = cmd.ExecuteReader();
            while (sqldatareader.Read())
            {
                Trasgressore trasgressore = new Trasgressore(
                    Convert.ToInt32(sqldatareader["IdAnagrafica"]),
                    sqldatareader["Cognome"].ToString(),
                    sqldatareader["Nome"].ToString(),
                    sqldatareader["Indirizzo"].ToString(),
                    sqldatareader["Citta"].ToString(),
                    Convert.ToInt32(sqldatareader["Cap"]),
                    sqldatareader["CodiceFiscale"].ToString()
                    );
                TrasgressoriList.Add( trasgressore );
            }
            conn.Close();
            return (TrasgressoriList);
        }
        public static void CreaViolazione(Violazioni violazione)
        {
            try 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO TIPO_VIOLAZIONE (Descrizione)" +
                                   "VALUES(@Descrizione)";
                cmd.Parameters.AddWithValue("@Descrizione", violazione.DescrizioneViolazione);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {

            }
            finally { conn.Close(); }
        }
        public static List<Violazioni> ListaViolazioni()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM TIPO_VIOLAZIONE", conn);
            SqlDataReader sqldatareader;
            conn.Open();
            List<Violazioni>violazioniList = new List<Violazioni>();
            sqldatareader = cmd.ExecuteReader();
            while (sqldatareader.Read())
            {
                Violazioni violazioni = new Violazioni(
                    Convert.ToInt32(sqldatareader["IdViolazione"]),
                    sqldatareader["Descrizione"].ToString()
                    );
                violazioniList.Add( violazioni );
            }
            conn.Close();
            return (violazioniList);
        }
        public static void CreaVerbale(Verbale verbale) 
        {
            try 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO VERBALE (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica,IdViolazione)" +
                                   "VALUES (@DataViolazione, @IndirizzoViolazione, @NominativoAgente, @DataTrascrizioneVerbale, @Importo, @DecurtamentoPunti, @IdAnagrafica, @IdViolazione)";
                cmd.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione);
                cmd.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
                cmd.Parameters.AddWithValue("@NominativoAgente", verbale.NominativoAgente);
                cmd.Parameters.AddWithValue("@DataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale);
                cmd.Parameters.AddWithValue("@Importo", verbale.Importo);
                cmd.Parameters.AddWithValue("@DecurtamentoPunti", verbale.DecurtamentoPunti);
                cmd.Parameters.AddWithValue("@IdAnagrafica", verbale.IdTrasgressore);
                cmd.Parameters.AddWithValue("@IdViolazione", verbale.IdViolazione);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex) 
            {

            }
            finally {conn.Close(); }
        }
        public static List<Verbale> ListaVerbali()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM VERBALE", conn);
            SqlDataReader sqldatareader;
            conn.Open();
            List<Verbale>verbaliList = new List<Verbale>();
            sqldatareader = cmd.ExecuteReader();
            while (sqldatareader.Read())
            {
                Verbale verbali = new Verbale(
                    Convert.ToInt32(sqldatareader["IdVerbale"]),
                    DateTime.Parse(sqldatareader["DataViolazione"].ToString()),
                    sqldatareader["IndirizzoViolazione"].ToString(),
                    sqldatareader["NominativoAgente"].ToString(),
                    DateTime.Parse(sqldatareader["DataTrascrizioneVerbale"].ToString()),
                    Convert.ToDouble(sqldatareader["Importo"]),
                    Convert.ToInt32(sqldatareader["DecurtamentoPunti"]),
                    Convert.ToInt32(sqldatareader["IdAnagrafica"]),
                    Convert.ToInt32(sqldatareader["IdViolazione"])
                    );
                verbaliList.Add( verbali );
            }
            conn.Close();
            return (verbaliList);
        }

        // Lista Verbali per ciascun trasgressore
        public static List<VerbaliPerTrasgressori> VerbaliPerOgniTrasgressore()
        {
            SqlCommand cmd = new SqlCommand("SELECT ANAGRAFICA.IdAnagrafica,Cognome,Nome, COUNT(*) AS TotaleVerbali FROM VERBALE INNER JOIN ANAGRAFICA ON ANAGRAFICA.IdAnagrafica = VERBALE.IdAnagrafica GROUP BY ANAGRAFICA.IdAnagrafica,Cognome,Nome",conn);
            SqlDataReader sqldatareader;
            conn.Open();
            List<VerbaliPerTrasgressori> verbaliPers = new List<VerbaliPerTrasgressori>();
            sqldatareader = cmd.ExecuteReader();
            while (sqldatareader.Read())
            {
                VerbaliPerTrasgressori verb = new VerbaliPerTrasgressori();
                verb.IdTrasgressore = Convert.ToInt32(sqldatareader["IdAnagrafica"]);
                verb.Cognome = sqldatareader["Cognome"].ToString();
                verb.Nome = sqldatareader["Nome"].ToString();
                verb.TotaleVerbali = Convert.ToInt32(sqldatareader["TotaleVerbali"]);
                verbaliPers.Add( verb );
            }
            conn.Close();
            return verbaliPers;
        }
        
        // Lista punti decurtati per ciascun trasgressore
        public static List<PuntiDecPerTrasgressore> PuntiPerOgniTrasgressore()
        {
            SqlCommand cmd = new SqlCommand("SELECT ANAGRAFICA.IdAnagrafica, Cognome, Nome, SUM(DecurtamentoPunti) AS TotalePuntiPersi FROM VERBALE INNER JOIN ANAGRAFICA ON ANAGRAFICA.IdAnagrafica = VERBALE.IdAnagrafica GROUP BY ANAGRAFICA.IdAnagrafica, Cognome, Nome", conn);
            SqlDataReader sqldatareader;
            conn.Open();
            List<PuntiDecPerTrasgressore> puntiDecurtati = new List<PuntiDecPerTrasgressore>();
            sqldatareader = cmd.ExecuteReader();
            while (sqldatareader.Read())
            {
                PuntiDecPerTrasgressore pd = new PuntiDecPerTrasgressore();
                pd.Id = Convert.ToInt32(sqldatareader["IdAnagrafica"]);
                pd.Cognome = sqldatareader["Cognome"].ToString();
                pd.Nome = sqldatareader["Nome"].ToString();
                pd.TotalePuntiDec = Convert.ToInt32(sqldatareader["TotalePuntiPersi"]);
                puntiDecurtati.Add( pd );
            }
            conn.Close();
            return puntiDecurtati;
        }

        // Lista trasgressori alla quale sono stati decurtati +10 punti
        public static List<ViolazioneOver10Punti> PuntiOver10PerOgniTrasgressore()
        {
            SqlCommand cmd = new SqlCommand("SELECT Cognome, Nome, DataViolazione, Importo, DecurtamentoPunti FROM VERBALE INNER JOIN ANAGRAFICA ON ANAGRAFICA.IdAnagrafica = VERBALE.IdAnagrafica WHERE DecurtamentoPunti > 10", conn);
            SqlDataReader sqldatareader;
            conn.Open();
            List<ViolazioneOver10Punti> puntiOver10 = new List<ViolazioneOver10Punti> ();
            sqldatareader = cmd.ExecuteReader();
            while (sqldatareader.Read())
            {
                ViolazioneOver10Punti violazione = new ViolazioneOver10Punti();
                violazione.Nome = sqldatareader["Nome"].ToString();
                violazione.Cognome = sqldatareader["Cognome"].ToString();
                violazione.DataViolazione = DateTime.Parse(sqldatareader["DataViolazione"].ToString());
                violazione.Importo = Convert.ToDouble(sqldatareader["Importo"]);
                violazione.PuntiDec = Convert.ToInt32(sqldatareader["DecurtamentoPunti"]);
                puntiOver10.Add(violazione);
            }
            conn.Close();
            return puntiOver10;
        }

        // Lista trasgressori i quali hanno ricevuto verbali +400€
        public static List<VerbaliOver400> VerbaliOver400PerTrasgressore()
        {
            SqlCommand cmd = new SqlCommand("SELECT Cognome, Nome, DataViolazione, Importo, DecurtamentoPunti FROM VERBALE INNER JOIN ANAGRAFICA ON ANAGRAFICA.IdAnagrafica = VERBALE.IdAnagrafica WHERE Importo > 400",conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            List<VerbaliOver400> over400 = new List<VerbaliOver400>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                VerbaliOver400 verb = new VerbaliOver400();
                verb.Cognome = sqlDataReader["Cognome"].ToString();
                verb.Nome = sqlDataReader["Nome"].ToString();
                verb.DataViolazione = DateTime.Parse(sqlDataReader["DataViolazione"].ToString());
                verb.Importo = Convert.ToDouble(sqlDataReader["Importo"]);
                verb.PuntiDecurtati = Convert.ToInt32(sqlDataReader["DecurtamentoPunti"]);
                over400.Add(verb);
            }
            conn.Close();
            return over400;
        }
    }
}