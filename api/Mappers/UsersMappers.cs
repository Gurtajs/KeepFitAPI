using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.DTOs.Users;

namespace api.Mappers
{
  public static class UsersMappers
{
	public static UsersDto ToUsersDto(this Users usersModel)
	{
		return new UsersDto
		{
			UserId = usersModel.UserId,
			Email = usersModel.Email,
			FirstName = usersModel.FirstName,
			LastName = usersModel.LastName,
			Age = usersModel.Age,
			ProfilePicture = usersModel.ProfilePicture,
			Weight = usersModel.Weight,
			Height = usersModel.Height
		};
	}
	public static Users ToUsersFromCreateDto(this CreateUsersRequestDto usersDto)
	{
		return new Users
		{
			Email = usersDto.Email,
			FirstName = usersDto.FirstName,
			LastName = usersDto.LastName,
			Age = usersDto.age,
			ProfilePicture = usersDto.ProfilePicture,
			Weight = usersDto.Weight,
			Height = usersDto.Height
		};
	}
}
}