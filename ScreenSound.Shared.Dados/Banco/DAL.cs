using ScreenSound.Modelos;
using System.Threading.Channels;

namespace ScreenSound.Banco;
public class DAL<T> where T : class
{
    private readonly ScreenSoundContext _context;

    public DAL(ScreenSoundContext context)
    {
        _context = context;
    }

    public IEnumerable<T> Listar()
    {
        try
        {
            return _context.Set<T>().ToList();

        }
        catch (Exception)
        {

            throw;
        }
    }
    public void Adicionar(T objeto)
    {
        _context.Set<T>().Add(objeto);
        _context.SaveChanges();
    }
    public void Atualizar(T objeto)
    {
        _context.Set<T>().Update(objeto);
        _context.SaveChanges();
    }
    public void Deletar(T objeto)
    {
        _context.Set<T>().Remove(objeto);
        _context.SaveChanges();
    }

    public T? RecuperarPor(Func<T, bool> condicao)
    {
        return _context.Set<T>().FirstOrDefault(condicao);
    }

    public IEnumerable<T> ListarPor(Func<T, bool> condicao)
    {
        return _context.Set<T>().Where(condicao);
    }

}
