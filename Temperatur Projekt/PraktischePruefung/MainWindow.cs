using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;
using System.IO.Ports;

namespace PraktischePruefung
{
    
    public partial class MainWindow : Form
    { 
        // SQL Variablen
        String connectionString = "SERVER=localhost;DATABASE=temperatur;UID=root;PASSWORD=;"; // Verbindung zur lokalen Datenbank
        MySqlConnection connection { get; set;  }
        MySqlConnection connection2 { get; set; }
        MySqlCommand command = null;
        MySqlDataReader dataReader;
        Boolean connectedToDatabase = false;

        //  Serielle Schnitstelle
        private SerialPort sPort1 = new SerialPort();
        public delegate void AddDataDelegate(String myString);
        public AddDataDelegate myDelegate;
        String outPutVoltage = ""; // Voltage wird auf 0 gesetzt, da noch keine vorliegt


        public MainWindow()
        {
            InitializeComponent();
            GetAvaialblePorts();
            ConnectToDatabase();
            LoadDataFromDatabase();
            OpenSerialPort();
            this.myDelegate = new AddDataDelegate(AddDataMethod);                      
        }
        void OpenSerialPort() // Serielle Schnittstelle
        {
            if ( this.cmBxCOMPorts.SelectedIndex != -1)
            {
                sPort1.Close();
                sPort1 = new SerialPort(this.cmBxCOMPorts.SelectedItem.ToString(), 9600, Parity.None, 8, StopBits.One);
                sPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
                sPort1.Open(); // Serielle Schnittstelle öffnen
            }
           
        }
        void GetAvaialblePorts() // Verfügbare Ports erkennen und Box anzeigen
        {
            String[] ports = SerialPort.GetPortNames();
            cmBxCOMPorts.Items.AddRange(ports);
        }
        private void SerialPort_DataReceived(object sender,SerialDataReceivedEventArgs e) // Methode ob Daten empfangen wurden
        {
            SerialPort sp = (SerialPort)sender;
            sp.NewLine = ";"; 
            string data = sp.ReadLine(); 
            SevSegDis_1.Invoke(myDelegate, data); // Methode um die Variableneinzelteile voneinander zu trennen
        }
        public void AddDataMethod(String myString) 
        {
            // Dezimal Nummer Umwandlung
            this.outPutVoltage = "";
            int tempInt = 0;
            tempInt  = Convert.ToInt32(myString) / 1000;
            this.outPutVoltage += tempInt;
            this.outPutVoltage += ".";
            tempInt = (Convert.ToInt32(myString) % 1000) / 100;
            this.outPutVoltage += tempInt;
            tempInt = (Convert.ToInt32(myString) % 100) / 10;
            this.outPutVoltage += tempInt;
            this.SevSegDis_1.Value = outPutVoltage;
            this.SevSegDis_1.Update(); // 7 Segment Anzeige aktualisieren nachdem der Wert auf Dezimal umgewandelt wurde

        }
        
        public void ConnectToDatabase() // Verbindung mit der Datenbank aufbauen
        {
            SevSegDis_1.Value = null; // 7 Segment Anzeige zurücksetzen auf Standart
            SevSegDis_1.Update();

            connection = new MySqlConnection(connectionString);
            connection2 = new MySqlConnection(connectionString);
            try
            {
                connection.Open(); // Verbindung zut Datenbank aufbauen
                connection2.Open();
                connectedToDatabase = true;
            }
            catch
            {
                MessageBox.Show("Fehlerhafte Verbindung zur Datenbank."); // Kann keine Verbindung aufbauen
            }
        }
        public void DisconnectFromDatabase() // Datenbank Verbindung trennen
        {
            if (connectedToDatabase == true) // Falls Verbindung vorhanden
            {
                connection.Close();
                connection2.Close();
            }
            else // Falls keine Verbindung vorhanden ist
            {
                MessageBox.Show("Nicht mit Datenbank verbunden.");
            }
        }
        public void LoadDataFromDatabase() // Aus der Datenbank lesen
        {
            if (connectedToDatabase)
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM temperaturen;";
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    String temperatur = Convert.ToString(dataReader[0]); // Wert speichern in Variable
                }
                dataReader.Close();
            }            
        }

        public ArrayList GetSNs() // Serielle Nummern 
        {
            if (connectedToDatabase)
            {
                ArrayList sns = new ArrayList();
                this.command.CommandText = "SELECT * FROM temperatur";
                this.dataReader = this.command.ExecuteReader();
                while (dataReader.Read())
                {
                    sns.Add(dataReader[0].ToString());
                }
                dataReader.Close();
                return sns;
            }
            else
            {
                return null;
            }
        }

        private void cmBxCOMPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenSerialPort(); // Serielle Schnitstelle öffnen
        }

        private void btnStartMessung_Click(object sender, EventArgs e) // Wenn Messung starten gedrückt
        {
            if (connectedToDatabase)
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM temperaturen;"; // Datenbank auslesen
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    String temperatur = Convert.ToString(dataReader[0]); // Wert aus DB speichern
                    SevSegDis_1.Value = temperatur;
                    SevSegDis_1.Update(); // Temperatur aktualisieren
                }
                dataReader.Close();
            }
            else
            {
                MessageBox.Show("Nicht mit Datenbank verbunden.");
            }
        }
    }
    interface IMainWindow // Main Window
    {
        ArrayList GetRooms();
        ArrayList GetSNs();
    }
}