﻿using ElectronicLibrary.Services.Models;
using System.Threading.Tasks;

namespace ElectronicLibrary.Services.Interfaces
{
    public interface IBookingManager
    {
        Task<bool> ReserveAsync(BookingModel model);
        Task<bool> TakeAsync(); 
    }
}
