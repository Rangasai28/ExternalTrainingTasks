using WebApiFiltersTask.DTOs;

namespace WebApiFiltersTask.Services;

public class TokenService
{
    public List<TokenDto> _tokens { get; set; }

    public TokenService()
    {
        _tokens = new List<TokenDto>();
    }

    public void AddToken(TokenDto obj)
    {
        _tokens.Add(obj);
    }

    public bool IsUserExists(string email)
    {
        return _tokens.Exists(x => x.Email == email);
    }

    public void RemoveToken(string token)
    {
        var userTokenDTO = _tokens.FirstOrDefault(x => x.Token == token);
        if (userTokenDTO != null)
        {
            _tokens.Remove(userTokenDTO);
        }
    }
}
