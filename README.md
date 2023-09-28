# TesseractOCRPlugin

[![Windows Build](https://github.com/JakeTrans/TesseractOCRPlugin/actions/workflows/dotnet.yml/badge.svg)](https://github.com/JakeTrans/TesseractOCRPlugin/actions/workflows/dotnet.yml)

Tesseract OCR (5.20) with Accord Image Processing to improve quality 


This is a implemention of Charles Weld's Tesseract dot.net wrapper https://github.com/charlesw/tesseract along with the Accord .net framework (my fork of the framework to fix the .Net Core build) https://github.com/JakeTrans/framework to create a OCR engine with automated image enhancement.  


By using Accord's Deskewing/Sharpening and Grayscaling filters the OCR rate has improved greatly.

the repo contains a Sample Application with a example usage.

if you find any issues or have any improvements please either submit Issues or feel free to submit a pull request.

Sample usage

add the dll, Tessdata and x64/x86 folders to your Project and the following will do a OCR of the image set and display the result as a Message Box:

```
Public Void OCRThis(string imagepath)
{
 TesseractOCR TessOCR = new TesseractOCR("eng", TesseractOCR.Quality.High);
 MessageBox.Show (TessOCR.OCRimage(imagepath));
}
