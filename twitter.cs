static bool AddValue(string value, string[] data, int count)
{
	if (count >= data.Length) {
		Console.WriteLine("I'm afraid I can't do that.");
		return false;
	}

	data[count] = value;
	return true;
}

static bool RemoveValue(string[] data, int index, int count)
{
	if (index < 0 || index >= count) {
		Console.WriteLine("I'm afraid I can't do that.");
		return false;
	}

	for (int i = index; i < count - 1; i += 1) {
		data[i] = data[i + 1];
	}
	data[count - 1] = "";
	return true;
}


static void AddUser(string username, string[] users, ref int userCount)
{
	int index = Array.IndexOf(users, username);
	if (index >= 0) {
		Console.WriteLine("User already exists.");
		return;
	}

	if (AddValue(username, users, userCount)) {
		userCount += 1;
	}
}

static void RemoveUser(string username, string[] users, ref int userCount)
{
	int index = Array.IndexOf(users, username);
	if (index < 0) {
		Console.WriteLine("User does not exist.");
		return;
	}

	if (index >= 0 && RemoveValue(users, index, userCount)) {
		userCount -= 1;
	}
}


static void AddPost(string post, string author, string[] posts, string[] postAuthors, ref int postCount)
{
    int index = Array.IndexOf(posts, post);
    int index2 = Array.IndexOf(postAuthors, author);
    if (index >= 0)
    {
        Console.WriteLine("Post already exists.");
        return;
    }
    if (index2 < 0)
    {
        Console.WriteLine("Author doesn't exist");
        return;
    }
    if (AddValue(post, posts, postCount))
    {
        postCount += 1;
    }
}
}

static string[] GetUserPosts(string user, string[] posts, string[] postAuthors, int postCount)
{
	int index = Array.IndexOf(postAuthors, user);
	if (index < 0)
	{
		Console.WriteLine("User hasn´t made any posts yet or doesn't exist");
		return;
    }
	
	string[] userPosts = new string[postCount];
	for (int i == 0; i < postCount;)
	{
		for (int j == 0; j < posts.Length; j++)
		{
			if (postAuthors[j] == user);
			{
				userPosts[i] = posts[j];
				i++;
			}
		}
	}
	return userPosts;
 }


static void AddFollow(string follower, string followee, string[] followers, string[] followees, ref int followCount)
{
	if (follower == followee) {
		Console.WriteLine("User cannot follow itself");
		return;
	}
	int followerIndex = Array.IndexOf(follower, followers);
	int followeeIndex = Array.IndexOf(followee, followees);
	if (followerIndex == followeeIndex) {
		Console.WriteLine("These users already follow each other.");
		return;
	}
	followers[followCount] = follower;
	followees[followCount] = followee;
	followCount++;
	return;
}

static void RemoveFollow(string follower, string followee, string[] followers, string[] followees, ref int followCount)
{
	int followerIndex = Array.IndexOf(follower, followers);
	int followeeIndex = Array.IndexOf(followee, followees);
	if (followerIndex != followeeIndex) {
		Console.WriteLine("These users already follow each other.");
		return;
	}
	if (removeValue(followers, follower, followCount) && (followees, followee, followCount))
	{
		followCount--;
		return;
	}
}

static string[] GetUserFollows(string user, string[] followers, string[] followees, int followCount)
{
	int index = Array.IndexOf(user, followers);
	if (index < 0) {
		Console.WriteLine("This user is not following anybody.");
		return;
	}
	string[] userFollows = new string[followCount];
	for (int i == 0; i < followCount;) {
		for (int j == 0; j < followCount.Length; j++) {
			if (followers[j] == user) {
				userFollows[i] = followees[j];
				i++;
			}
		}
	}
	return userFollows;
}

static string[] GetUserFollowers(string user, string[] followers, string[] followees, int followCount)
{
	int index = Array.IndexOf(user, followees);
	if (index < 0) {
		Console.WriteLine("Nobody follows this user.");
		return;
	}
	string[] userIsFollowed = new string[followCount];
	for (int i ==0; i < followCount;) {
		for (int j == 0; j < followCount.Length; j++) {
			if (followees[j] == user) {
				userIsFollowed[i] = followers[j];
				i++;
			}
		}
	}
	retuen userIsFollowed;
}


// Bonus
static string[] GetUserTimeline(string user, string[] posts, string[] postAuthors, int postCount, string[] followers, string[] followees, int followCount)
{
	// TODO
	return new string[] { };
}


int MAX_USERS = 100;
int MAX_POSTS = MAX_USERS * 100;
int MAX_FOLLOWS = MAX_USERS * (MAX_USERS + 1) / 2;

string[] users = new string[MAX_USERS];
int userCount = 0;

string[] posts = new string[MAX_POSTS];
string[] postAuthors = new string[MAX_POSTS];
int postCount = 0;

string[] followers = new string[MAX_FOLLOWS];
string[] followees = new string[MAX_FOLLOWS];
int followCount = 0;

AddUser("wormik", users, ref userCount);
