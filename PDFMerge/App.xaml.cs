// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Path = System.IO.Path;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PDFMerge
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        private MainWindow m_window;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            Console.WriteLine(args);

            //string pathDir = "";
            //using (PdfDocument outPdf = new PdfDocument())
            //{
            //    foreach (var path in SelectedItemPaths)
            //    {
            //        using (PdfDocument inputPdf = PdfReader.Open(path, PdfDocumentOpenMode.Import))
            //        {
            //            CopyPDFPages(inputPdf, outPdf);
            //        }

            //        pathDir = Path.GetDirectoryName(path);
            //    }

            //    string saveFileAs = Path.Combine(pathDir, "merged.pdf");
            //    outPdf.Save(saveFileAs);
            //}

            m_window = new MainWindow();
            m_window.Activate();

            if (args.Arguments == null || args.Arguments == "")
                return;

            var paths = new string[1];
            paths[0] = args.Arguments;

            m_window.FilePaths = paths;
        }

        private void CopyPDFPages(PdfDocument from, PdfDocument to)
        {
            for (int i = 0; i < from.PageCount; i++)
            {
                to.AddPage(from.Pages[i]);
            }
        }

    }
}
