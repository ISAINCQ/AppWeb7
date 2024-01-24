using Data;
using Entity;

namespace Negocio
{
    public class MedicamentoNegocio
    {
        public List<MedicamentoEntity> getMedicamentos()
        {
            var objMedicamentoData = new MedicamentoData();
            return objMedicamentoData.getMedicamentos();
        }
        public MedicamentoEntity getMedicamentoById(int IdMedicamento)
        {
            var objMedicamentoData = new MedicamentoData();
            return objMedicamentoData.getMedicamentoById(IdMedicamento);
        }
        public bool DeleteMedicamento(int IdMedicamento)
        {
            var objMedicamentoData = new MedicamentoData();
            return objMedicamentoData.DeleteMedicamento(IdMedicamento);
        }
        public bool AddMedicamento(MedicamentoEntity obj)
        {
            var objMedicamentoData = new MedicamentoData();
            return objMedicamentoData.AddMedicamento(obj);
        }
        public bool UpdateMedicamento(MedicamentoEntity obj)
        {
            var objMedicamentoData = new MedicamentoData();
            return objMedicamentoData.AddMedicamento(obj);
        }
    }
}
