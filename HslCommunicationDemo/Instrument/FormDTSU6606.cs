﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using HslCommunication;
using HslCommunication.Instrument.Delixi;
using System.IO.Ports;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
    public partial class FormDTSU6606 : HslFormContent
    {
        public FormDTSU6606( )
        {
            InitializeComponent( );
        }

        private DTSU6606Serial delixi = null;

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            comboBox1.SelectedIndex = 2;



            comboBox2.SelectedIndex = 0;
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            checkBox3.CheckedChanged += CheckBox3_CheckedChanged;

            comboBox3.DataSource = SerialPort.GetPortNames( );
            try
            {
                comboBox3.SelectedIndex = 0;
            }
            catch
            {
                comboBox3.Text = "COM3";
            }

            Language( Program.Language );


            hslCurve1.SetLeftCurve( "电压A", null );
            hslCurve1.SetLeftCurve( "电压B", null );
            hslCurve1.SetLeftCurve( "电压C", null );
            hslCurve1.SetRightCurve( "频率", null );
        }


        private void Language( int language )
        {
            if (language == 2)
            {
                Text = "Delixi Read Demo";

                label1.Text = "Com:";
                label3.Text = "baudRate:";
                label22.Text = "DataBit";
                label23.Text = "StopBit";
                label24.Text = "parity";
                label21.Text = "station";
                checkBox1.Text = "address from 0";
                checkBox3.Text = "string reverse";
                button1.Text = "Connect";
                button2.Text = "Disconnect";

                label11.Text = "Address:";
                label12.Text = "length:";
                label13.Text = "Results:";
                label16.Text = "Message:";
                label14.Text = "Results:";
                groupBox5.Text = "Special function test";

                comboBox1.DataSource = new string[] { "None", "Odd", "Even" };
            }
        }

        private void CheckBox3_CheckedChanged( object sender, EventArgs e )
        {
            if (delixi != null)
            {
                delixi.IsStringReverse = checkBox3.Checked;
            }
        }

        private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (delixi != null)
            {
                switch (comboBox2.SelectedIndex)
                {
                    case 0: delixi.DataFormat = HslCommunication.Core.DataFormat.ABCD; break;
                    case 1: delixi.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
                    case 2: delixi.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
                    case 3: delixi.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
                    default: break;
                }
            }
        }


        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {

        }


        #region Connect And Close



        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int baudRate ))
            {
                MessageBox.Show( DemoUtils.BaudRateInputWrong );
                return;
            }

            if (!int.TryParse( textBox16.Text, out int dataBits ))
            {
                MessageBox.Show( DemoUtils.DataBitsInputWrong );
                return;
            }

            if (!int.TryParse( textBox17.Text, out int stopBits ))
            {
                MessageBox.Show( DemoUtils.StopBitInputWrong );
                return;
            }


            if (!byte.TryParse( textBox15.Text, out byte station ))
            {
                MessageBox.Show( "Station input wrong！" );
                return;
            }

            delixi?.Close( );
            delixi = new DTSU6606Serial( station );
            delixi.AddressStartWithZero = checkBox1.Checked;
            delixi.LogNet = LogNet;


            ComboBox2_SelectedIndexChanged( null, new EventArgs( ) );
            delixi.IsStringReverse = checkBox3.Checked;


            try
            {
                delixi.SerialPortInni( sp =>
                 {
                     sp.PortName = comboBox3.Text;
                     sp.BaudRate = baudRate;
                     sp.DataBits = dataBits;
                     sp.StopBits = stopBits == 0 ? System.IO.Ports.StopBits.None : (stopBits == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
                     sp.Parity = comboBox1.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (comboBox1.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
                 } );
                delixi.RtsEnable = checkBox5.Checked;
                delixi.Open( );

                button2.Enabled = true;
                button1.Enabled = false;
                panel2.Enabled = true;

                userControlReadWriteOp1.SetReadWriteNet( delixi, "100", false );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            delixi.Close( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }

        #endregion

        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlCom, comboBox3.Text );
            element.SetAttributeValue( DemoDeviceList.XmlBaudRate, textBox2.Text );
            element.SetAttributeValue( DemoDeviceList.XmlDataBits, textBox16.Text );
            element.SetAttributeValue( DemoDeviceList.XmlStopBit, textBox17.Text );
            element.SetAttributeValue( DemoDeviceList.XmlParity, comboBox1.SelectedIndex );
            element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );
            element.SetAttributeValue( DemoDeviceList.XmlAddressStartWithZero, checkBox1.Checked );
            element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox2.SelectedIndex );
            element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox3.Checked );
            element.SetAttributeValue( DemoDeviceList.XmlRtsEnable, checkBox5.Checked );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            comboBox3.Text = element.Attribute( DemoDeviceList.XmlCom ).Value;
            textBox2.Text = element.Attribute( DemoDeviceList.XmlBaudRate ).Value;
            textBox16.Text = element.Attribute( DemoDeviceList.XmlDataBits ).Value;
            textBox17.Text = element.Attribute( DemoDeviceList.XmlStopBit ).Value;
            comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlParity ).Value );
            textBox15.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
            checkBox1.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlAddressStartWithZero ).Value );
            comboBox2.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );
            checkBox3.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlStringReverse ).Value );
            checkBox5.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlRtsEnable ).Value );
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }

        private void button3_Click( object sender, EventArgs e )
        {
            OperateResult<ElectricalParameters> read = delixi.ReadElectricalParameters( );
            if (read.IsSuccess)
            {
                ShowElectrical( read.Content );
            }
            else
            {
                MessageBox.Show( "Read Failed: " + read.Message );
            }
        }

        private void ShowElectrical( ElectricalParameters electrical )
        {
            textBox1.Text = electrical.VoltageA.ToString( );
            textBox3.Text = electrical.VoltageB.ToString( );
            textBox4.Text = electrical.VoltageC.ToString( );
            textBox5.Text = electrical.CurrentA.ToString( );
            textBox6.Text = electrical.CurrentB.ToString( );
            textBox7.Text = electrical.CurrentC.ToString( );
            textBox8.Text = electrical.Frequency.ToString( );

            textBox9.Text = electrical.InstantaneousActivePowerA.ToString( );
            textBox10.Text = electrical.InstantaneousActivePowerB.ToString( );
            textBox11.Text = electrical.InstantaneousActivePowerC.ToString( );
            textBox13.Text = electrical.InstantaneousTotalActivePower.ToString( );
            textBox14.Text = electrical.InstantaneousReactivePowerA.ToString( );
            textBox18.Text = electrical.InstantaneousReactivePowerB.ToString( );
            textBox19.Text = electrical.InstantaneousReactivePowerC.ToString( );
            textBox20.Text = electrical.InstantaneousTotalReactivePower.ToString( );

            textBox21.Text = electrical.InstantaneousApparentPowerA.ToString( );
            textBox22.Text = electrical.InstantaneousApparentPowerB.ToString( );
            textBox23.Text = electrical.InstantaneousApparentPowerC.ToString( );
            textBox24.Text = electrical.InstantaneousTotalApparentPower.ToString( );
            textBox25.Text = electrical.PowerFactorA.ToString( );
            textBox26.Text = electrical.PowerFactorB.ToString( );
            textBox27.Text = electrical.PowerFactorC.ToString( );
            textBox28.Text = electrical.TotalPowerFactor.ToString( );
        }

        private Timer timer;
        bool timerRead = false;
        private void button4_Click( object sender, EventArgs e )
        {
            // 定时读取
            if (timerRead)
            {
                timerRead = false;
                timer?.Dispose( );
                button4.Text = "定时读取";
            }
            else
            {
                timerRead = true;
                timer = new Timer( );
                timer.Interval = int.Parse( textBox12.Text );
                timer.Tick += Timer_Tick;
                timer.Start( );
                button4.Text = "Stop";
            }
        }

        private void Timer_Tick( object sender, EventArgs e )
        {
            OperateResult<ElectricalParameters> read = delixi.ReadElectricalParameters( );
            if (read.IsSuccess)
            {
                ShowElectrical( read.Content );
                hslCurve1.AddCurveData(
                    new string[] { "电压A", "电压B", "电压C", "频率" },
                    new float[] { read.Content.VoltageA, read.Content.VoltageB, read.Content.VoltageC, read.Content.Frequency } );
            }
        }
    }
}
