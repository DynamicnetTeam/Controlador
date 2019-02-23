// #define DEBUGA
using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp1
{

    class Program
    {
        private bool bInsertoCompras;

        public bool BInsertoCompras { get => bInsertoCompras; set => bInsertoCompras = value; }
        

        public string getRuta(string path, int posic = 1)
        {
            try
            {
                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    // Open the stream and read it back.
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        int i = 1; 
                        while (i <= posic)
                        {
                            s = sr.ReadLine();
                            i++;
                        }
                        return s;
                    }
                }
                else
                {
                    return "";
                }

            }

            catch
            {
                return "";
            }
        }

        static void Main(string[] args)
        {

            
            FEControlador.FEControladorLibrary FEControl = new FEControlador.FEControladorLibrary();
            var p = new Program();


            try
            {
                
                FEControl.RutaServidor = p.getRuta(@"rutaServidor.txt");
                /*FEControl.RutaComprasAceptar = p.getRuta(@"rutasXMLCompras.txt");
                FEControl.RutaComprasRechazar = p.getRuta(@"rutasXMLCompras.txt", 2);
                FEControl.RutaComprasAceptadas = p.getRuta(@"rutasXMLCompras.txt", 3);
                FEControl.RutaComprasRechazadas = p.getRuta(@"rutasXMLCompras.txt", 4);*/
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            while (true)
            {
#if DEBUGA
                MessageBox.Show("Entra al while(true)");
#endif    


                string[] words = p.getRuta(@"rutaBDLocal.txt").Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
#if DEBUGA
                MessageBox.Show("Primer Elemento:" + words[0]);
#endif                
                foreach (string word in words)
                {
                    FEControl.RutaBDLocal = word;


#if DEBUGA
                    MessageBox.Show("Intentando con BD" + word);
#endif
                    FEControl.RutaBDLocal = word;
                    try
                    {
                        FEControl.crearTabla("PARAMETRO", " (ID VARCHAR(30),VALOR VARCHAR(80))");
                    }
                    catch (Exception E)
                    {
#if DEBUGA
                        MessageBox.Show(E.Message);
#endif
                    }
#if DEBUGA
                    MessageBox.Show("Subiendo Ventas");
#endif
                    FEControl.uploadFacturasSysfac();
#if DEBUGA
                    MessageBox.Show("Insertando Compras");
#endif
                    try
                    {
                        FEControl.insertarCompras();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

#if DEBUGA
                    MessageBox.Show("Termina Insertando Compras");
#endif
#if DEBUGA
                    MessageBox.Show("Insertando Compras Rech");
#endif
                    try
                    {
                        FEControl.insertarCompras(false);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
#if DEBUGA
                    MessageBox.Show("Insertando Compras Rech Termina");
#endif

                }
#if DEBUGA
                MessageBox.Show("Antes de Sleep:" + words[0]);
#endif      
                Thread.Sleep(20000);
#if DEBUGA
                MessageBox.Show("Sale de Sleep:" + words[0]);
#endif    
            }

        }
    }
}
