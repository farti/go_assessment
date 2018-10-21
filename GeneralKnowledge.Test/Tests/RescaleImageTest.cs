using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Kaliko.ImageLibrary;
using Kaliko.ImageLibrary.Scaling;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Image rescaling
    /// </summary>
    public class RescaleImageTest : ITest
    {
        public void Run()
        {
            // TODO:
            // Grab an image from a public URL and write a function thats rescale the image to a desired format
            // The use of 3rd party plugins is permitted
            // For example: 100x80 (thumbnail) and 1200x1600 (preview)


            // Install-Package ImageLibrary
            // https://www.nuget.org/packages/ImageLibrary/


            var image = new KalikoImage(@"https://web.usask.ca/images/homer.jpg");
            image.SaveJpg(@"C:\MyImages\org.jpg", 99);

            // Create thumbnail by cropping
            KalikoImage thumb = image.Scale(new CropScaling(128, 128));
            thumb.SaveJpg(@"C:\MyImages\thumbnail-fit.jpg", 99);

            // Create preview 1200x1600
            image.Resize(1600,1200);
            image.SaveJpg(@"C:\MyImages\preview.jpg",99);

            Console.WriteLine("Images saved to C:\\MyImages\\");

        }


    }
}
