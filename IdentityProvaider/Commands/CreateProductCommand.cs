﻿namespace IdentityProvaider.API.Commands
{
    public record CreateProductCommand(string title, string description, string image, int rating, int price);
}
