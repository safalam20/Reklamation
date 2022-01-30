using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Reklamation.Models;

namespace Reklamation.Services
{
    public class ExportExcel
    {
        public void exportToExcel(List<KTrkl_Positionen> Positions, List<KTrkl_TxtGrund> _Grunds)
        {
            var newFile = @"wwwroot\files\newbook.core.xlsx";

            using (var fs = new FileStream(newFile, FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet1 = workbook.CreateSheet("Sheet1");

                IRow HeaderRow = sheet1.CreateRow(0);

                CreateCell(HeaderRow, 0, "Rek_ID");
                CreateCell(HeaderRow,1,	"Mandant");
CreateCell(HeaderRow,2,	"Status");
CreateCell(HeaderRow,3,	"Kundennummer");
CreateCell(HeaderRow,4,	"AuftragsJahr");
CreateCell(HeaderRow,5,	"Kundennam");
CreateCell(HeaderRow,6,	"ReklamationsSystemDatum");
CreateCell(HeaderRow,7,	"ArtGruppe");
CreateCell(HeaderRow,8,	"ArtikelGruppe");
CreateCell(HeaderRow,9,	"Artikelnummer");
CreateCell(HeaderRow,10,"GrundK_ID");
CreateCell(HeaderRow,11,"GrundU_ID");
CreateCell(HeaderRow,12,"HatKundeRecht");
CreateCell(HeaderRow,13,"Bemerkung");
CreateCell(HeaderRow,14,"ProduktionsJahr");
CreateCell(HeaderRow,15,"ProduktionsbatchDatum");
CreateCell(HeaderRow,16,"SerialNoSerienNr");
CreateCell(HeaderRow,17,"Hersteller");
CreateCell(HeaderRow,18,"DotWocheJahr");
CreateCell(HeaderRow,19,"RestProfiltief");
CreateCell(HeaderRow,20,"KMGefahren");
CreateCell(HeaderRow,21,"Menge");
CreateCell(HeaderRow,22,"Bezeichnung1");
CreateCell(HeaderRow,23,"PrFehler");
CreateCell(HeaderRow,24,"ErgebnisWare");
CreateCell(HeaderRow,25,"gesMenge");
CreateCell(HeaderRow,26,"gesArtikelnummer");






                int RowIndex = 1;

                foreach(KTrkl_Positionen p in Positions)
                {
                    if(p.Reklamation != null)
                    {
                        IRow CurrentRow = sheet1.CreateRow(RowIndex);


                        ICreateCell(CurrentRow, 0, p.Reklamation.Rek_ID);
                        CreateCell(CurrentRow,1, p.Reklamation.	Mandant.ToString());
                        CreateCell(CurrentRow,2, p.Reklamation.	Status);
                        CreateCell(CurrentRow,3, p.Reklamation.	Kundennummer);
                        if (p.Reklamation.AuftragsJahr == null)
                        {
                            CreateCell(CurrentRow, 4, p.Reklamation.AuftragsJahr.ToString());
                        }
                        else
                        {
                            ICreateCell(CurrentRow, 4,(int) p.Reklamation.AuftragsJahr);
                        }
                        
                        CreateCell(CurrentRow,5, p.Reklamation.	Kundenname);                        
                        CreateCell(CurrentRow, 6, p.Reklamation.ReklamationsSystemDatum.ToString());                       
                        CreateCell(CurrentRow,7,p.	ArtGruppe);
                        CreateCell(CurrentRow,8,p.	ArtikelGruppe);
                        CreateCell(CurrentRow,9,p.	Artikelnummer);
                        CreateCell(CurrentRow,10,GetGrundByID(_Grunds,p.GrundK_ID));
                        CreateCell(CurrentRow,11, GetGrundByID(_Grunds, p.GrundU_ID));
                        CreateCell(CurrentRow,12,p.	HatKundeRecht);
                        CreateCell(CurrentRow,13,p.	Bemerkung);

                        if (p.ProduktionsJahr != null)
                        {
                            ICreateCell(CurrentRow, 14,(int) p.ProduktionsJahr);
                        }
                        else
                        {
                            CreateCell(CurrentRow, 14, p.ProduktionsJahr.ToString());
                        }
                        
                        CreateCell(CurrentRow,15,p.ProduktionsbatchDatum);
                        CreateCell(CurrentRow,16,p.SerialNoSerienNr);
                        CreateCell(CurrentRow,17,p.Hersteller);
                        CreateCell(CurrentRow,18,p.DotWocheJahr);
                        CreateCell(CurrentRow,19,p.RestProfiltiefe);
                        CreateCell(CurrentRow,20,p.KMGefahren.ToString());

                        if (p.Menge != null)
                        {
                            ICreateCell(CurrentRow, 21,(int) p.Menge);
                        }
                        else
                        {
                            CreateCell(CurrentRow, 21, p.Menge.ToString());
                        }
                        
                        CreateCell(CurrentRow,22,p.	Bezeichnung1);
                        CreateCell(CurrentRow,23,p.	PrFehler);
                        CreateCell(CurrentRow,24,p.	ErgebnisWare);
                        CreateCell(CurrentRow,25,p.gesMenge.ToString());
                        CreateCell(CurrentRow,26,p.	gesArtikelnummer);


                        RowIndex++;
                    }
                    
                }

                workbook.Write(fs);
            }
        }

        private void CreateCell(IRow CurrentRow, int CellIndex, string Value)
        {
            ICell Cell = CurrentRow.CreateCell(CellIndex);
            Cell.SetCellValue(Value);
        }
        private void ICreateCell(IRow CurrentRow, int CellIndex, int Value)
        {
            ICell Cell = CurrentRow.CreateCell(CellIndex);
            Cell.SetCellValue(Value);
        }

        string GetGrundByID(List<KTrkl_TxtGrund> _Grunds,int? id)
        {
            if (id != null)
            {
                return _Grunds.Find(g => g.Grund_ID == id).Grund;
            }
            else
            {
                return "";
            }

        }



    }
}
