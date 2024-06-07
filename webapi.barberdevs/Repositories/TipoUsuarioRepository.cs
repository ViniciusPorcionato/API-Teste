﻿using webapi.barberdevs.Contexts;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Interfaces;

namespace webapi.barberdevs.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly BarberDevsContext _context;

        public TipoUsuarioRepository()
        {
            _context = new BarberDevsContext();
        }
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _context.TipoUsuario.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    tipoUsuarioBuscado.NomeTipoUsuario = tipoUsuario.NomeTipoUsuario;
                }

                _context.TipoUsuario.Update(tipoUsuarioBuscado!);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            return _context.TipoUsuario.Find(id)!;
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _context.TipoUsuario.Add(tipoUsuario);
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
                TipoUsuario tipoUsuarioBuscado = _context.TipoUsuario.Find(id)!;
                if (tipoUsuarioBuscado != null)
                {
                    _context.TipoUsuario.Remove(tipoUsuarioBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoUsuario> Listar()
        {
            try
            {
                return _context.TipoUsuario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
