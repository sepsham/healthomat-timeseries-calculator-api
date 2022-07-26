using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesCalculator.Application.ModelDto.Authentication.Queries;

public record UserDto(string Username,Guid ObjectId,string Group);
