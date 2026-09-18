I needed a web-compatible project to pad my CV. There were many ideas, but the main one was to create the 
traditional project of some CRUD website. I don't have any reason to create a CRUD application for my data, since 
I don't host anything with user-generated content -- deciding it is better to do it manually than open up security.

So this leaves us with the need of an open API that is actually useful, I don't want to spend all of my time making 
some useless weather or "TODO" site. Thankfully, Riot Games is very generous with their API access and allow basically 
anyone to interact with their services "within reason". Unsurprisingly, I was unable to come up with a good name and 
decided on a "temporary" name of "YALST", or "Yet Another League Stat Tracker".

# Version 1

_yes, unfortunately, there is a version 2..._

## Stack

Since I've had a recent programming "renaissance" with my love for C#, I decided to implement both YALST and Kitten.rs 
in C# with the Blazor framework. This exact choice provided the advantage of integrating directly with EntityFramework 
and using Microsoft's IdentityCore authentication setup, meaning authentication is as simple as clicking "include 
authentication" in Rider.

### Front-end

During development, I whipped up a quick prototype using server-side rendering for the core functionality. I chose this 
as a way to create a minimum viable product as it simplified interacting with the database enough to allow for rapid 
development _(this certainly will not cause problems later)_.

### Back-end

#### Riot API

To facilitate interacting with the Riot API, I decided to create a singleton service that handles all communications to 
and from the Riot API. Any concerns about performance due to re-using HTTP clients is negated by the fact that my API 
key is limited to just 20 requests per second, or 100 requests per 2 minutes. 

Obviously 20 requests per seconds is not enough, especially when you can only max that out for 5 seconds every 2 minutes, 
when each game has anywhere from 10 to 20 API requests per. I hear you "stop using so many API requests then!", but 
I want to store every summoner that is in every game. I hate op.gg not storing a game for a participant just because 
you didn't click update. 

Part of optimising these 20 or so API calls is having an intermediate database for storing the information received 
from the API. Doing this prevents hitting the API for summoners that already exist, reducing the API hits 
by at least 1 for every game. Unfortunately, with most games having 9+ new players, this isn't enough. 
So I created a queueing system for actions performed in the API.

Every action that a user attempts to make with the API is instead sent to an action queue that slowly processes each 
action. If an action is rate limited, then its just sent back to the front of queue. Meaning that if you click update, 
then eventually the website will update and collect all required information.

#### Data Dragon

Data Dragon is Riot's name for their server that stores static information about League of Legends, think champion 
icons or summoner spell information. Riot archive pretty much every bit of data that lands on the Data Dragon, if needed 
you could pull up summoner spell information for Season 3. Seeing this gave me the idea that in the future, I could 
use the game version stored per match to ensure all images and information is accurate to that version of the game. 
Quite commonly stat websites, like OP.GG or DPM.lol, don't do this, and it causes matches from previous seasons to 
be missing items or have completely wrong information on those builds.

## The Skill Issue

There is one problem that you probably noticed with how this version operates. When a user loads a summoner, the 
***entire*** stored match history must be sent over all at once. This not only increases page load time, but also breaks the 
web-socket connection that is established to the server. So the solution is to only send a few matches at a time, and 
request more when the user is at the bottom of the page right?

To get this functionality the blazor component must be set to an InteractiveWebassembly render mode, permitting the 
client-side to update itself over an API. Unfortunately, I seemed to have fucked up my environment at some point. 
No matter what, switching to InteractiveWebassembly rendering would instantly kill the connection due to missing a 
service I did not request. There is absolutely zero information on why this error is occuring, not even giving up and 
yolo'ing the entire thing to Gemini gave any information. From what I can tell, some vengeful ghost is sitting in that 
code-base.

# Version 2

## Stack

Nothing can be said to be certain, except death, taxes, and JavaScript in the front-end. Try as I might, I just can't 
run from Java/TypeScript forever, and so have decided to completely separate the front from the back-end. Thankfully, 
ASP.NET is a perfect standalone back-end, 90% of my work with the database and queue system can remain exactly the same 
in this transition. If you think about it, I'm just like Solomon cutting a project in half because of some nuisance.

As part of this split, I had to decide on a new front-end. I'm no stranger to JavaScript, I've created a few websites 
with Node.Js, made a Firefox extension, and had to read a few codebases consisting of JavaScript and CoffeeScript. 
This experience is why I've decided to choose a front-end that is has TypeScript as a first-party. I cannot stand 
JavaScript and its disgusting quirks, I need some sort of type-safety to remain sane, so I chose Angular as the front-end 
framework. I had absolutely no other reason to choose Angular, since I have no favourite front-end. To me, asking me to choose 
a favourite front-end is like asking which torture method I'd prefer to wake up to tonight.

## Back-End

As previously mentioned, the back-end is mostly the same as from V1. The only major difference is that now I've had to 
make a controller for everything, and figure out how to add API authentication for the account-based compilation match 
histories.

## Front-End

Most of the work in the front-end is just figuring out how to write Angular. Data Dragon and back-end API access were 
sent to live in their own services, even completely removing some issues I had with DataDragon in V1. Due to the differences 
of Blazor and Angular, I was even able to re-add the theme system from my previous site "Lilith.rs". Previous attempts 
in Blazor had constant white flashes on every page navigation, whilst now it seems to just be limited to when the 
user first opens the website.


# Closing Thoughts

Honestly, this experience has been kind of magical. Using Blazor with server-side rendering is perfect, it just works; 
trying to make Blazor work client-side is less perfect. Many issues are faced with "just use JavaScript", and I feel 
like it's just half-baked. Biting the bullet and transitioning to TypeScript has shown me why almost everyone uses a 
JS front-end, although I don't quite understand why they then decide to run a JS back-end.

## Blazor 

As mentioned, Blazor in the client side feels half-baked; the fault isn't even Blazor, it's Web Assembly. Web Assembly 
was meant to revolutionise web development, but it's still a second-class citizen. You can't modify the DOM, and you 
have to rely on JavaScript for nearly everything that your chosen framework doesn't natively provide. 

Honestly, I think in the future I'll probably stick to splitting the front and back-end until Web Assembly improves 
enough to become a First-Class citizen in the web-ecosystem.

Fuck JavaScript though. Give me types or give me death.