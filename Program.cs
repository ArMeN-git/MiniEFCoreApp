using Microsoft.EntityFrameworkCore;
using MiniEFCoreApp;
using MiniEFCoreApp.Entities;
using System.Data;

using var context = new DemoContext();
// insert data for test

//var c1 = new Client
//{
//    UserId = 101,
//    Type = ClientType.Buyer,
//    Notes = null,
//    IsActive = true,
//    InvitationData = null,
//    CreateDate = DateTime.Now,
//    IsDeleted = false,
//    DeletionDate = null
//};
//await context.Clients.AddAsync(c1);

//var c2 = new Client
//{
//    UserId = 102,
//    Type = ClientType.Renter,
//    Notes = null,
//    IsActive = true,
//    InvitationData = null,
//    CreateDate = DateTime.Now,
//    IsDeleted = false,
//    DeletionDate = null
//};
//await context.Clients.AddAsync(c2);

//var c3 = new Client
//{
//    UserId = 103,
//    Type = ClientType.Renter,
//    Notes = null,
//    IsActive = true,
//    InvitationData = null,
//    CreateDate = DateTime.Now,
//    IsDeleted = false,
//    DeletionDate = null
//};
//await context.Clients.AddAsync(c3);

//await context.SaveChangesAsync();

//await context.HomeTours.AddAsync(new HomeTour
//{
//    CoreListingId = 172,
//    Type = HomeTourType.InPersonTour,
//    StartTime = DateTime.Now,
//    EndTime = DateTime.Now,
//    ClientId = c1.Id,
//    CreateDate = DateTime.Now
//});

//await context.UserViews.AddAsync(new UserView
//{
//    UserId = 102,
//    CoreListingId = 172,
//    Count = 2,
//    CreateDate = DateTime.Now
//});

//await context.SaveChangesAsync();

int _userId = 777;
var clientsQuery = context.Clients.Where(c => c.ClientAgents.Any(ac => ac.AgentUserId == _userId));
var firstQuery = context.HomeTours
                .Where(c => c.Type == HomeTourType.InPersonTour)
                .Select(c => new ListingAction
                {
                    UserId = c.Client.UserId,
                    Action = ClientListingAction.AddedHomeTour,
                    CreateDate = c.CreateDate
                });
var secondQuery = context.UserViews
                .Select(c => new ListingAction
                {
                    UserId = c.UserId,
                    Action = ClientListingAction.Viewed,
                    CreateDate = c.CreateDate
                });
var unionedQuery = firstQuery.Union(secondQuery);
var orderedQuery = unionedQuery.OrderByDescending(c => c.CreateDate);
var joinedQuery = clientsQuery.GroupJoin(orderedQuery, c => c.UserId, la => la.UserId, (c, la) => new { Client = c, Actions = la })
                              .SelectMany(a => a.Actions.DefaultIfEmpty(), (a, la) => new
                              {
                                  a.Client.UserId,
                                  a.Client.Type,
                                  Weight = 1 // just other value, doesn't matter
                              });

// throws SQL Exception
var result = await joinedQuery.ToListAsync();