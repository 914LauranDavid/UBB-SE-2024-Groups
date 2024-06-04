INSERT INTO Users (UserId, Username, FullName, Password, Email, PhoneNumber, BirthDay, CreatedDate)
VALUES ('2fda6ef7-ca09-4c63-9c25-dd4e31f67374', 'defaultUsername', 'defaultFullName', 'defaultPassword', 'defaultEmail@example.com', '000-000-0000', '2000-01-01', GETDATE())


INSERT INTO Groups (GroupId, OwnerId, GroupName, Description, CreatedDate, IsPublic, AllowanceOfPostage)
VALUES (
    NEWID(),
    '2fda6ef7-ca09-4c63-9c25-dd4e31f67374',
    'Sample Group',
    'sample group description.',
    GETDATE(),
    1,
    1
);

INSERT INTO MarketplacePosts (
    MarketplacePostId,
    AuthorId,
    GroupId,
    Title,
    Description,
    MediaContent,
    Location,
    CreationDate,
    EndDate,
    IsPromoted,
    IsActive,
    Type,
    DonationLink,
    CurrentDonationAmount,
    Price,
    IsNegotiable,
    DeliveryType,
    CurrentPriceLeader,
    CurrentBidPrice,
    MinimumBidPrice
)
VALUES (
    NEWID(),
    '2fda6ef7-ca09-4c63-9c25-dd4e31f67374',
    '9f7061d4-a193-4e63-87f1-8fc4c2251aed',
    'Sample Post Title',
    'sample post description.',
    NULL,
    'Sample Location',
    GETDATE(),
    NULL,
    0,
    1,
    'Donation',
    NULL,
    NULL,
    100.00,
    1,
    'Donation',
    NULL,
    NULL,
    NULL
);

INSERT INTO UsersFavoritePosts(UserId, MarketplacePostId)
VALUES ('2fda6ef7-ca09-4c63-9c25-dd4e31f67374', '516b13cd-6064-44d9-90c5-401a2956f84a');