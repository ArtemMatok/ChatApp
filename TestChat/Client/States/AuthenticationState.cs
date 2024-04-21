using System.ComponentModel;
using TestChat.Shared.DTOs;

namespace TestChat.Client.States
{
    public class AuthenticationState : INotifyPropertyChanged
    {
        public const string AuthStoreKey = "authkey";

        public event PropertyChangedEventHandler? PropertyChanged;
        public UserDto User { get; set; } = default;
        public string? Token { get; set; }
        public bool _isAuthenticated  { get; set; }
        public bool IsAuthenticated
        {
            get => _isAuthenticated;
            set
            {
                if(_isAuthenticated != value)
                {
                    _isAuthenticated = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAuthenticated)));
                }
            }
        }

        public void LoadState(AuthResponseDto authResponseDto)
        {
            User = authResponseDto.User;
            Token = authResponseDto.Token;
            IsAuthenticated = true;
        }

        public void UnloadState()
        {
            User = default;
            Token = null;
            IsAuthenticated = false;
        }
    }
}
