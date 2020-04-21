using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

using Giftins.Core.Domain.User;
using Giftins.Application.Account.Create;

namespace Giftins.Application.Account
{
    public class AccountMapperProfile : Profile
    {
        public override string ProfileName => nameof(AccountMapperProfile);

        public AccountMapperProfile()
        {
            AddMemberConfiguration();

            CreateMap<CreateAccountCommand, GiftinsUser>()
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x => x.PhoneNumber, o => o.MapFrom(e => e.Phone))
                .ForMember(x => x.Language, o => o.Ignore())
                .ForMember(x => x.EmailConfirmed, o => o.Ignore())
                .ForMember(x => x.PhoneNumberConfirmed, o => o.Ignore())
                .ForMember(x => x.Enabled, o => o.Ignore())
                .ForMember(x => x.NormalizedUserName, o => o.Ignore())
                .ForMember(x => x.NormalizedEmail, o => o.Ignore())
                .ForMember(x => x.PasswordHash, o => o.Ignore())
                .ForMember(x => x.TwoFactorEnabled, o => o.Ignore())
                .ForMember(x => x.SecurityStamp, o => o.MapFrom(e => Guid.NewGuid().ToString()))
                .ForMember(x => x.ConcurrencyStamp, o => o.Ignore())
                .ForMember(x => x.LockoutEnd, o => o.Ignore())
                .ForMember(x => x.AccessFailedCount, o => o.Ignore());

            CreateMap<GiftinsUser, UserProfile>()
                .ForMember(x => x.UserId, o => o.MapFrom(e => e.Id))
                .ForMember(x => x.FirstName, o => o.Ignore())
                .ForMember(x => x.LastName, o => o.Ignore())
                .ForMember(x => x.Birthdate, o => o.Ignore())
                .ForMember(x => x.GenderId, o => o.Ignore())
                .ForMember(x => x.RelationId, o => o.Ignore())
                .ForMember(x => x.BirthDisplayPolicyId, o => o.Ignore())
                .ForMember(x => x.RelationDisplayPolicyId, o => o.Ignore())
                .ForMember(x => x.PictureId, o => o.Ignore())
                .ForMember(x => x.Country, o => o.Ignore())
                .ForMember(x => x.City, o => o.Ignore());

            CreateMap<CreateAccountCommand, UserProfile>()
                .ForMember(x => x.UserId, o => o.Ignore())
                .ForMember(x => x.GenderId, o => o.Ignore())
                .ForMember(x => x.RelationId, o => o.Ignore())
                .ForMember(x => x.Country, o => o.Ignore())
                .ForMember(x => x.City, o => o.Ignore())
                .ForMember(x => x.PictureId, o => o.Ignore())
                .ForMember(x => x.RelationDisplayPolicyId, o => o.Ignore())
                .ForMember(x => x.BirthDisplayPolicyId, o => o.Ignore());
        }
    }
}
