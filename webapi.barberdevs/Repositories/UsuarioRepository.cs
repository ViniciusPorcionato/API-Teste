using webapi.barberdevs.Contexts;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Interfaces;
using webapi.barberdevs.Utils;

namespace webapi.barberdevs.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BarberDevsContext _context;

        public UsuarioRepository()
        {
            _context = new BarberDevsContext();
        }
        public bool AlterarSenha(string email, string senhaNova)
        {
            try
            {
                var user = _context.Usuario.FirstOrDefault(x => x.Email == email);

                if (user == null)
                {
                    return false;
                }

                user.Senha = Criptografia.GerarHash(senhaNova);
                _context.Update(user);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AtualizarFoto(Guid id, string novaUrlFoto)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario.FirstOrDefault(x => x.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    usuarioBuscado.Foto = novaUrlFoto;
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        IdTipoUsuarioNavigation = new TipoUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuarioNavigation!.IdTipoUsuario,
                            NomeTipoUsuario = u.IdTipoUsuarioNavigation!.NomeTipoUsuario
                        }
                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado == null)
                {
                    return null!;
                }

                if (!Criptografia.CompararHash(senha, usuarioBuscado.Senha))
                {
                    return null!;
                }

                return usuarioBuscado;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                return _context.Usuario.FirstOrDefault(x => x.IdUsuario == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha);

                _context.Usuario.Add(usuario);

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario.Find(id)!;

                if (usuarioBuscado != null)
                {
                    _context.Usuario.Remove(usuarioBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
