# TesseractOCRPlugin
[![Build Status](https://dev.azure.com/JTGithubBuildPipeline/CSVEditorBuild/_apis/build/status/JakeTrans.CSVEditor?branchName=master)](https://dev.azure.com/JTGithubBuildPipeline/CSVEditorBuild/_build/latest?definitionId=8&branchName=master)

Tesseract OCR (4.00) with Accord Image Processing to improve quality

(the 3.04 version branch is here: https://github.com/JakeTrans/TesseractOCRPlugin/tree/tesseract-3.04-Version)

This is a implemention of Charles Weld's Tesseract dot.net wrapper https://github.com/charlesw/tesseract along with the Accord .net framework https://github.com/accord-net/framework  to create a OCR engine with automated image enhancement.  


By using Accord's Deskewing/Sharpening and Grayscaling filters the OCR rate has improved greatly.

the Zip contains a Sample Application with a example usage.

if you find any issues or have any improvements please either submit Issues or feel free to submit a pull request.

Sample usage

add the dll, Tessdata and x64/x86 folders to your Project and the following will do a OCR of the image set and display the result as a Message Box:

```
Public Void OCRThis(string imagepath)
{
 TesseractOCR TessOCR = new TesseractOCR("eng", TesseractOCR.Quality.High);
 MessageBox.Show (TessOCR.OCRimage(imagepath));
}
