﻿using ClientsApi.Application.Enums;

namespace ClientsApi.Application.Dtos
{
    public class CreateClientDto
    {
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public byte Age { get; set; }
        public string Identification { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}