using System.Threading.Tasks;

namespace PagouFacil.DTO
{
    public class SucessDTO
    {
        public bool sucess { get; private set; }
        public string message { get; private set; }
        public string target { get; private set; }
        public string? error { get; private set; }

        public SucessDTO(){}

        public async Task setSucess(string target)
        {
            this.sucess = true;
            this.message = "Arquivo gerado com sucesso!";
            this.target = target;
        }

        public async Task setFailure(string error)
        {
            this.sucess = false;
            this.message = "Ocorreu um erro na geração do arquivo.";
            this.error = error;
        }
    }
}
