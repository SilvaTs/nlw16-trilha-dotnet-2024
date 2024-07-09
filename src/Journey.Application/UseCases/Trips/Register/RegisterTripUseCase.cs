﻿using Journey.Communication.Requests;
using Journey.Exception.ExceptionsBase;

namespace Journey.Application.UseCases.Trips.Register;

public class RegisterTripUseCase
{
    public void Execute(RequestRegisterTripJson request)
    {
        Validate(request);
    }

    private void Validate(RequestRegisterTripJson request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new JourneyException("Nome não pode ser vazio");
        }

        if (request.StartDate.Date < DateTime.UtcNow.Date)
        {
            throw new JourneyException("Viagem não pode ser registrada para uma data passada.");
        }

        if (request.EndDate.Date < request.StartDate.Date)
        {
            throw new JourneyException("A viagem deve terminar após a data de início.");
        }
    }
}
