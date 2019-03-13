using SOW.Dominio.Commands.Usuarios;

namespace SOW.Aplicacao.Interfaces
{
    public interface IUsuarioAppServico
    {
        void Registrar(UsuarioCriacaoCommand usuarioCriacaoCommand);
    }
}
