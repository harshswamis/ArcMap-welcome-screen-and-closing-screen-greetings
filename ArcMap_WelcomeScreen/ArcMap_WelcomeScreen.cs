using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using WindowsForms_WelcomeScreen;
using System.Windows.Forms;

namespace ArcMap_WelcomeScreen
{
    public class ArcMap_WelcomeScreen : ESRI.ArcGIS.Desktop.AddIns.Extension
    {
        Form1 form;
        WindowsForms_ClosingScreen.Form1 form1;

        public ArcMap_WelcomeScreen()
        {
            form = new Form1();
            form1 = new WindowsForms_ClosingScreen.Form1();

        }

        protected override void OnStartup()
        {
             WireDocumentEvents();
        }

        private void WireDocumentEvents()
        {
            //
            // TODO: Sample document event wiring code. Change as needed
            //

            // Named event handler
            ArcMap.Events.NewDocument += delegate () { ArcMap_NewDocument(); };

            // Anonymous event handler
            ArcMap.Events.BeforeCloseDocument += delegate ()
            {
                // Return true to stop document from closing
                //ESRI.ArcGIS.Framework.IMessageDialog msgBox = new ESRI.ArcGIS.Framework.MessageDialogClass();
                //      return msgBox.DoModal("BeforeCloseDocument Event", "Abort closing?", "Yes", "No", ArcMap.Application.hWnd);

                ArcMap_CloseDocument();
                return false;

            };

        }

        void ArcMap_CloseDocument()
        {
            form1.ShowDialog();
        }

        void ArcMap_NewDocument()
        {
            form.ShowDialog();
        }

    }

}
