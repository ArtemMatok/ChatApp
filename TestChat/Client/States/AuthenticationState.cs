﻿using System.ComponentModel;
using TestChat.Shared.DTOs;

namespace TestChat.Client.States
{
    public class AuthenticationState : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string? Name { get; set; }
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
            Name = authResponseDto.Name;
            Token = authResponseDto.Token;
            IsAuthenticated = true;
        }

        public void Unload()
        {
            Name = null;
            Token = null;
            IsAuthenticated = false;
        }
    }
}