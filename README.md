# ReportGenerateBarcode
Genera codigo de barras

1. BarcodeLib
2. Framework 4.6.2
3. System.Drawing.Common
4. programar boton
5. agregamos dataSet, renombramos AppData, agregamos una Datatable(Id, Text,Image)
6. agregamos AppData1
7. programar AppData1
8. agregamos Microsoft.ReportingServices webForms
9. agregamos Microsoft.ReportingServices WinForms
10. agregamos formulario para reportes frmReport
11. Agregamos reportviewver de sql, Dock=fill
12. Agregamos nuevo elemento reporte, new DataSet, agregamos rectangulo
    image(tamaño original), textbox(text).
13. agregamos una table
14. en frmReport agregamos el reporte RDLC
15. programos el frmReport
16. configurar rowvisibility
=IIf(RowNumber(nothing) mod 2=1, false, true)
=IIf(RowNumber(nothing) mod 2=0, false, true)