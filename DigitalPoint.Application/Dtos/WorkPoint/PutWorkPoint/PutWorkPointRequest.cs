using System.ComponentModel.DataAnnotations;

namespace DigitalPoint.Application.Dtos.WorkPoints.PutWorkPoint
{
    public class PutWorkPointRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DepartureTime { get;  set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime EntryTime { get;  set; }

    }
}
