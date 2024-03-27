# TesseractOCRPlugin

[![Build Status](https://dev.azure.com/JTGithubBuildPipeline/TesseractPluginMasterBuild/_apis/build/status/JakeTrans.TesseractOCRPlugin?branchName=master)](https://dev.azure.com/JTGithubBuildPipeline/TesseractPluginMasterBuild/_build/latest?definitionId=10&branchName=master)

Tesseract OCR (4.1) with IronDrawing and Emgu CV to improve quality and Compatibility

(Please note I've done this to make things work better for cross platform , I've kept a branch with the Accord Version)


This is a implemention of Charles Weld's Tesseract dot.net wrapper https://github.com/charlesw/tesseract along with the  to 
Emgu CV create a OCR engine with automated image enhancement.  


By using Iron Drawing Deskewing/Sharpening and Grayscaling filters to improve the OCR rate Deskewing is done via EmguCV.

the repo contains a Sample Application with a example usage and some basic unit tests.

if you find any issues or have any improvements please either submit Issues or feel free to submit a pull request.

Sample usage

add the dll, Tessdata and x64/x86 folders to your Project and the following will do a OCR of the image set and display the result as a Message Box:

```
Public Void OCRThis(string imagepath)
{
 TesseractOCR TessOCR = new TesseractOCR("eng", TesseractOCR.Quality.High);
 MessageBox.Show (TessOCR.OCRimage(imagepath));
}
