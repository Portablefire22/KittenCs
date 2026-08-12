"Let's set the scene for this project. It's the 17th of January 2025 and YouTube started to recommend various
videos about the now defunct "ChronoShift" project - videos of which can be found
[here](https://www.youtube.com/playlist?list=PLfVEn_PNuKhDQjnsdOVGVByutEilSkzLK). I had always been acutely aware of the
ChronoShift project but never thought much of it until I remembered a
[Reddit post about it being shutdown](https://www.reddit.com/r/leagueoflegends/comments/u7u7hv/chronoshift_an_emulation_of_2011_league_of/),
it saddened me quite a bit since I've always been interested in playing old versions of League of Legends. Hell, it
got to the point that it ***started appearing in my damn dreams***, and so I took it upon myself to get a part of
old League of Legends functional again."

That was the initial premise of the project. Fortunately for me, and 
unfortunate for my work, Riot Games decided to create a Frankenstein's 
Monster version of League classic; choosing to mix multiple patches 
instead of one singular patch. Now I could probably go on about how I 
intend to achieve **perfect** parity with the old client, but 
at this point the project has turned into a perfect portfolio display 
piece.


I'm going to be quite honest here, deciding how to write this has been
harder than writing my Dissertation. I barely made notes, and I would 
spend weeks progressing before remembering this page; now we're 
over one year in and I remember nearly nothing. So, this post is probably 
less on the technical and more just overall how things work. If I 
get bored, I'm sure that I'd end up creating a V3 of this that goes into 
more detail.

# Quick Introduction

Here's the TLDR for each component from my original write-up

## PvP.Net

[Associated Repo (RTMP)](https://github.com/Portablefire22/Neeko)

[Associated Repo (HTTP)](https://github.com/Portablefire22/Nexus)

PvP.Net is Riot's Attempt at Blizzard's Battle.Net, and is the name 
given to the Adobe Air Client that people love to reminisce about online.

![League of Legends Adobe Air client opened to a Maestro connection error](/img/kindred/maestro_error.png)

Seemingly requires two servers to function. One running an Adobe stack with 
Adobe Flex for directly communicating with the PvP.net client, and 
a secondary HTTP(S) server to provide account access + shop.

### RTMP

Real Time Messaging Protocl (RTMP) is Adobe's high-performance protocol 
for transferring audio, video, and audio. Once used widely, this protocol 
has become nearly extinct due to Adobe Flash exiting the consumer space. 
Most uses of RTMP now are exclusively streaming, e.g. Video sharing sites, 
or CCTVs.

### AMF

Action Message Format (AMF) is a binary data format used to serialize 
ActionScript objects and XML. Once again, this format was near exclusively 
used by Adobe's technologies and as such does not show up much these days. 
Effectively, this can be thought of as a non-text version of JSON but with 
some small compression built in. I built a simple tool for analysing AMF 
data that can be found [here!](/blog/AMF Viewer V1)

## Maestro

[Associated Repo](https://github.com/Portablefire22/Khada)

Maestro is League Of Legend's Middleware, it is responsible for bridging 
PvP.net and the In-Game Client together. If you've ever had a DM during a 
League game, then Maestro was used to forward the message from the Launcher 
to the Game. PvP.net will not move past launch without Maestro being active.

## XMPP

[Associated Repo](https://github.com/Portablefire22/Camille)

Extensible Messaging and Presence Protocol (XMPP) is an open-source
Messaging protocol that was modified by Riot Games for their chat and 
friend system. Whilst the specification for XMPP is open, Riot's extensions 
have not been officially made public. Thankfully, the client does not require the 
XMPP server to be running for PvP.net to function.

## League of Legends Game

*Repo does exist, but not public due to fears of* ***[Zed](/img/kindred/zed.png)***

The actual in-game client for League Of Legends, what you use to play 
a game. Due to being made in C++, this is effectively a black box that 
I have to prod or research on GitHub to interact with. Without a server,
the game will refuse to move past a black screen; with a server, the 
client can theoretically play a game of League of Legends.

# To be continued

If you're seeing this, then I still haven't finished this post. 
I've only pushed this to stop Kindred showing as a blank file :D
