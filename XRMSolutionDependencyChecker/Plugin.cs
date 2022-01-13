﻿using System.ComponentModel.Composition;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace XRMSolutionDependencyChecker
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "XRM Solution Dependency Checker"),
        ExportMetadata("Description", "List out dependencies that are missing from a source solution to the target environment"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAACxAAAAsQAa0jvXUAAASjSURBVFhH1VbtT1tVGP/d3ra37+8tLS9jUJjhZZgx0SEvyxgbOk0mgsumLsZkf4EmZnwwMWZ+84N+MllMjF80fNAsmTPTRXA6HdEIbIuQLaPQAZ20dLSlhfX1eO7hrkJgs7caib+bJ/e8PPc5v3Oel3s4AITKtkEhvbcN/28C/I4qcBql1CsORRPgndXQHRuA8HojtSKGUnEoigCnt0L34hlwai34BgfUfbukGfmQTYBTCtD3vguFyYXUyDByCwmo9ldA1VkhaciDbALanjfAe+qQnhxCavgTJD8aB0mkoe7fBb7WKmkVDtkE+LJ6ZAMTWLn4Ph5TadG5okby7DUgR6CoNElahUM2AeVqGuZfx4BMChyNvdP2CtTOppD8bFLSkAfZBEyjN2DX70GJ+xnEc1moOAXec+6EfTSMzC93Ja3CwVN5Z61ZGFYik7BYm2EyNyK4EkB0dR4dOjOaNQZcWlpEmsir7LJP4NDjSsxMnUUul4LT1YXBWAgX4vdQI2hwvOw/CMIPTtWgtTaBOzOfgki7/XBpHkZvEkYD68qC/CDkOQy+1QCPwYc/7p5nYwNNTnhdfFG/VdkEzgz6YTUocf7t3dBw0zhRZcGb9Q74aS34fDoqaRUO2UE45otDJyjwXIsD3TVmnKC1IJ7O4eiwn5EoBuLJyRIFx5EvBhrJ/Y/bSPh4Hely67fUK1C2HPxb0Qk8uXK6iZyqtW45X6j8oyuZXq1AIpWTesVh2++EG4KwpqYWPT3P0hrPIRqN4MiR51FX34A7fj9aW5/GU/takYjH0dLyJBNXSQm0Wh0OdnXDYrGA53n2vZm2g8EF9PcfQ1W1FzP+GWSzWVRWVlK7GzMln4ZKlQrtHZ04d+5LxBNxtLV34OatmxgfG8WBA10oKy/H1xe+QltbO4aHh9hiP1z+Hg6HA+PjYxgd/Q1msxkTE7/DSxcVBAHJVAr3wmHWLy0tw8Huw9JqfyFPQENLaSQSwerqKqZ9PmrMgrnZWQQC87Tum+mtS4FXT76GW5RUNpuhf1/CdiViT/Ne7NhRydodnfvZXCaTQVVVNZr3PoG5uVnsbmpCcGGBEnYyvQfIE4jHl6HVaHDocA+OvtCLG9evobe3D319L+E6bedIDkPfXYLesLne3qek9fq18Z+u/MhOR3Tj1NRtWi0DUKsFSnAnjEYjJdvM9NYjnxL0Q1JeXkFUKhXrW61WYrPb823xbbc7NvQNBgNxezzEZrMTrVZLNBoNsViszAZ1CRszmUxUz8j0bTYbez+QR2ZBiduNUDAIq82GVDLJxpaXl9lOxB8RzytBjSMWi9HxGNMPL4apFgElgHSaXl6o+0KhEPt2KzyUgHiEL79yEt9+cxENjY0Q6DFGY1GMXP0Z+2hGZDNZ+Hy3WWYEKUnRDeKidPfQ6XQsliI0k9R0bGTkqmR1Mx76M1IoFAjMz6Pa6wWh9z3xEUm53R62kJhqS0sRFrgZulNxLptbK0phGvlOlwuLi6F8cD4KG3yyXsR4UCpVxOl0MT/SXCfUINHr9YQeN9MR/Sz6V4wfmqpEoDEg6ooxIPrf4yndZHe9bHsllH0f+HcB/Am35+4aqYG7/QAAAABJRU5ErkJggg="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class Plugin : PluginBase
    {
        
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new PluginControl();
        }
    }
}