using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityDigitalSystem.Common.ISubTarServices
{
    public interface ITariffServices
    {
        void AddTariffToService();

        void PushToDb(TarriffModel model);

        List<TarriffModel> GetAllTariff();

        TarriffModel GetTarriffByName(string name);

        TarriffModel GetTarriffById(string id);
    }
}
