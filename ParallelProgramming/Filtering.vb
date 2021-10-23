Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class Filtering

    Public Shared Function MedianFilter(sourceBitmap As Bitmap, matrixSize As Integer, Optional grayScale As Boolean = False, Optional bias As Integer = 0) As Bitmap

#Disable Warning CA1416 ' Validate platform compatibility
        Dim sourceData As BitmapData = sourceBitmap.LockBits(New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                                                                ImageLockMode.ReadOnly,
                                                                PixelFormat.Format32bppArgb)

        Dim arraySize As Integer = sourceData.Stride * sourceData.Height
        Dim pixelBuffer(arraySize), resultBuffer(arraySize) As Byte

        Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length)
        sourceBitmap.UnlockBits(sourceData)

        If grayScale Then
            Dim rgb As Single

            For k = 0 To pixelBuffer.Length Step 4
                rgb = pixelBuffer(k) * 0.11F
                rgb += pixelBuffer(k + 1) * 0.59F
                rgb += pixelBuffer(k + 2) * 0.3F

                pixelBuffer(k) = Convert.ToByte(rgb)
                pixelBuffer(k + 1) = pixelBuffer(k)
                pixelBuffer(k + 2) = pixelBuffer(k)
                pixelBuffer(k + 3) = 255
            Next

        End If

        Dim filterOffset As Integer = (matrixSize - 1) / 2
        Dim calcOffset, byteOffset As Integer
        Dim neighbourPixels = New List(Of Integer)()
        Dim middlePixel() As Byte

        For offsetY = filterOffset To sourceBitmap.Height - filterOffset - 1 Step 1
            For offsetX = filterOffset To sourceBitmap.Width - filterOffset - 1 Step 1

                byteOffset = offsetY * sourceData.Stride + offsetX * 4

                neighbourPixels.Clear()

                For filterY = -filterOffset To filterOffset Step 1
                    For filterX = -filterOffset To filterOffset Step 1
                        calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride)
                        'Get argument exception
                        neighbourPixels.Add(BitConverter.ToInt32(pixelBuffer, calcOffset))
                    Next
                Next

                neighbourPixels.Sort()
                middlePixel = BitConverter.GetBytes(neighbourPixels(filterOffset))
                resultBuffer(byteOffset) = middlePixel(0)
                resultBuffer(byteOffset + 1) = middlePixel(1)
                resultBuffer(byteOffset + 2) = middlePixel(2)
                resultBuffer(byteOffset + 3) = middlePixel(3)
            Next
        Next

        Dim resultBitMap As Bitmap = New Bitmap(sourceBitmap.Width, sourceBitmap.Height)
        Dim resultData As BitmapData = resultBitMap.LockBits(New Rectangle(0, 0, resultBitMap.Width, resultBitMap.Height),
                                                             ImageLockMode.WriteOnly,
                                                             PixelFormat.Format32bppArgb)

        Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length)

        resultBitMap.UnlockBits(resultData)
#Enable Warning CA1416 ' Validate platform compatibility
        Return resultBitMap
    End Function
End Class
