namespace Celitech.Http.OAuth;

public record OauthToken(string AccessToken, HashSet<string> Scopes, int? ExpiresAt);
