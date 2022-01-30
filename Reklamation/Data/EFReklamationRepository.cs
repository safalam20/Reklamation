using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Reklamation.Models;
using Reklamation.Models.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Data
{
    public class EFReklamationRepository : IReklamationRepository
    {
        private ApplicationDBContext context;
        public EFReklamationRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }
        public async Task<List<KTEnumerator>> GetUsers()
        {
            var ktUsers = await context.KTEnumerators
                .Where(k => k.Type1.Equals("Reklamation"))
                .ToListAsync();

            return ktUsers;
               
        }
        public async Task<List<KTrkl_Reklamation>> GetAllReklamations()
        {
            var reklamations = await context._Reklamations
                .Include(r=>r.Positionens)
                .Include(r=>r.Bilds)
                .OrderByDescending(r=>r.Rek_ID)
                .ToListAsync();
            return reklamations;
        }
        public async Task<List<KTrkl_Reklamation>> GetProFehlerReklamations()
        {
            var reklamations = await context._Reklamations
                .Include(r => r.Positionens)
                .Include(r => r.Bilds)
                .OrderByDescending(r => r.Rek_ID)
                .Where(r=>r.Positionens.Any(p=>p.PrFehler=="1"))
                .ToListAsync();
            return reklamations;
        }
        public async Task AddNewReklamation(KTrkl_Reklamation reklamation)
        {
            context._Reklamations.Add(reklamation);
            await context.SaveChangesAsync();
        }
        public async Task SaveChangesReklamation()
        {
            await context.SaveChangesAsync();
        }
        public async Task SaveChangesNoParam()
        {          
            await context.SaveChangesAsync();
        }
        public List<KTrkl_Reklamation> UpdaterInfo(List<KTrkl_Reklamation> _Reklamations,string username)
        {
            foreach(KTrkl_Reklamation kr in _Reklamations)
            {
                if (context.Entry(kr).State == EntityState.Modified)
                {
                    kr.Updater = username;
                    kr.Updatedatum = DateTime.Now;
                }
            }

            return _Reklamations;
        }
        public async Task<List<BelegeDTO>> GetBelegeBySearch(string Kundennummer,DateTime? Belegdatum, string Auftragsnummer,
            string Lieferscheinnummer, string Rechnungsnummer,string Referenznummer)
        {
            var Kunde = new SqlParameter("@Kundennummer", Kundennummer);
            Kunde.Value = (object)Kundennummer ?? DBNull.Value;
            var Beleg = new SqlParameter("@Belegdatum", Belegdatum);
            Beleg.Value = (object)Belegdatum ?? DBNull.Value;
            var Auftrag = new SqlParameter("@Auftragsnummer", Auftragsnummer);
            Auftrag.Value = (object)Auftragsnummer ?? DBNull.Value;
            var Liefer = new SqlParameter("@Lieferscheinnummer", Lieferscheinnummer);
            Liefer.Value = (object)Lieferscheinnummer ?? DBNull.Value;
            var Rechnung = new SqlParameter("@Rechnungsnummer", Rechnungsnummer);
            Rechnung.Value = (object)Rechnungsnummer ?? DBNull.Value;
            var Referenz = new SqlParameter("@Referenznummer", Referenznummer);
            Referenz.Value = (object)Referenznummer ?? DBNull.Value;


            var BelegData = await context.Beleges
                .FromSqlRaw("Select * From[fnKT_rkl_FindBeleg_List](@Kundennummer,@Belegdatum, @Auftragsnummer, @Lieferscheinnummer, @Rechnungsnummer, @Referenznummer)",                
                Kunde,Beleg,Auftrag,Liefer,Rechnung,Referenz)
                .ToListAsync();

            return BelegData;
        }
        public async Task<List<BelegPosDTO>> GetBelegPosByBelegID(int BelID)
        {
            var pBelID = new SqlParameter("@BelID", BelID);

            var BelegPosList = await context.BelegPosList
                .FromSqlRaw("Select * From [fnKT_rkl_FindBelegPos_List] (@BelID) order by BelPosID", pBelID)
                .ToListAsync();

            return BelegPosList;

        }
        public async Task<List<KTrkl_TxtGrund>> GetAllGrunds()
        {
            var grunds = await context.TxtGrunds
                         .OrderBy(r => r.Grund)
                         .ToListAsync();
            return grunds;
        }
        public async Task<KTrkl_Positionen> GetPositionByPosID(int PosID)
        {
            var position = await context._Positionens.FindAsync(PosID);
            return position;
        }
        public async Task<KTrkl_Reklamation> GetReklamationByRekID(int RekID)
        {
            var reklamation = await context._Reklamations
                .Include(r=>r.Positionens)
                .FirstOrDefaultAsync(r=>r.Rek_ID==RekID);
            return reklamation;
        }
        public async Task<int> StornoRechnung801(int RekID)
        {
            var pRekID = new SqlParameter("@RekID", RekID);            
            var count = await context.Database
                .ExecuteSqlRawAsync("EXEC [dbo].[spKT_rkl_Reklamation_801_STR_Stor] @RekID", pRekID);
            return count;
        }
        public async Task<int> RVEStor802(int RekID)
        {
            var pRekID = new SqlParameter("@RekID", RekID);
            var count = await context.Database
                .ExecuteSqlRawAsync("EXEC [dbo].[spKT_rkl_Reklamation_802_RVS_RVEStor] @RekID", pRekID);
            return count;
        }
        public async Task<int> RVEAuft803(int RekID)
        {
            var pRekID = new SqlParameter("@RekID", RekID);
            var count = await context.Database
                .ExecuteSqlRawAsync("EXEC [dbo].[spKT_rkl_Reklamation_803_RVE_Auft] @RekID", pRekID);
            return count;
        }
        public async Task<StatusFehler> StatusCheckAsync(int Rek_ID)
        {
            var result = await context._Reklamations
                .Select(s => new StatusFehler()
                {
                    message = ApplicationDBContext.CheckStatus(Rek_ID)
                }).FirstOrDefaultAsync();

            return result;
            
        }
        public async Task<List<KTrkl_Positionen>> GetAllPositions()
        {
            var positions = await context._Positionens
                .Include(r => r.Reklamation)
                .OrderByDescending(r => r.Rek_ID)
                .ToListAsync();

            return positions;
        }    
        public async Task DeleteReklamation(KTrkl_Reklamation rekToDelete)
        {
            context._Reklamations.Remove(rekToDelete);
            await context.SaveChangesAsync();
        }
        public async Task<List<FunctionCheckDTO>> CheckFunctionContinue(int VorID)
        {
            var VorParam = new SqlParameter("@VorID", VorID);

            var query = await context.FunctionCheck
                .FromSqlRaw("Select Count(V.VorID) as CheckCount From KHKVKBelegeVorgaenge V Left Join KHKVKBelege B on B.Mandant = V.Mandant and B.BelID = V.BelID Where V.Mandant = 6 and B.Belegkennzeichen in ('VFR','VSR') and V.VorID = @VorID",VorParam)            
                .ToListAsync();

            return query;
        }
        public async Task<List<KTrkl_Message>> GetAllMessages()
        {
            var result = await context.KTrkl_MessagesDbSet
                .OrderBy(x=>x.Datum)
                .ToListAsync();

            return result;
        }
        public async Task SaveNewMessage(KTrkl_Message newMessage)
        {
            context.KTrkl_MessagesDbSet.Add(newMessage);
            await context.SaveChangesAsync();
        }

        public async Task UpdateUnReadMessages(List<KTrkl_Message> messagesToUpdate)
        {
            context.KTrkl_MessagesDbSet.UpdateRange(messagesToUpdate);
            await context.SaveChangesAsync();
        }

    }
}
