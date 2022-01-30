using Reklamation.Models;
using Reklamation.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Data
{
    interface IReklamationRepository
    {
        
        Task<List<KTrkl_Reklamation>> GetAllReklamations();
        Task<List<KTrkl_Reklamation>> GetProFehlerReklamations();
        Task SaveChangesReklamation();
        Task<List<BelegeDTO>> GetBelegeBySearch(string Kundennummer, DateTime? Belegdatum, string Auftragsnummer,
            string Lieferscheinnummer, string Rechnungsnummer, string Referenznummer);
        Task<List<BelegPosDTO>> GetBelegPosByBelegID(int BelID);     
        Task AddNewReklamation(KTrkl_Reklamation reklamation);
        Task<List<KTrkl_TxtGrund>> GetAllGrunds();
        Task<KTrkl_Positionen> GetPositionByPosID(int PosID);
        Task<int> StornoRechnung801(int RekID);
        Task<int> RVEStor802(int RekID);
        Task<int> RVEAuft803(int RekID);
        Task<KTrkl_Reklamation> GetReklamationByRekID(int RekID);
        Task<StatusFehler> StatusCheckAsync(int Rek_ID);
        Task<List<KTEnumerator>> GetUsers();
        Task<List<KTrkl_Positionen>> GetAllPositions();
        Task DeleteReklamation(KTrkl_Reklamation rekToDelete);
        Task SaveChangesNoParam();
        List<KTrkl_Reklamation> UpdaterInfo(List<KTrkl_Reklamation> _Reklamations, string username);
        Task<List<FunctionCheckDTO>> CheckFunctionContinue(int VorID);
        Task<List<KTrkl_Message>> GetAllMessages();
        Task SaveNewMessage(KTrkl_Message newMessage);
        Task UpdateUnReadMessages(List<KTrkl_Message> messagesToUpdate);
    }
}
