Oracle Cloud Infrastructure (OCI) recently limited 
their free server resources from 4 core, 24GB RAM to 
2 core, 12GB Ram. As I had imagined something like this 
happening, I opted to take two servers with an equal split 
of resources instead of a single instance. Thankfully this 
paid off, but it did mean that my newer website was 
without a home.

# Lilith.rs

Lilith.rs was intended to be an updated version of "Kitten.rs",
in fact Kitten.rs was supposed to be taken offline and converted 
into a testing area for websites. Clearly this never happened, 
with Lilith.rs being the eventual sacrifice to appease the 
OCI overlords, so I felt there was a need to update. 

Both Lilith.rs and Kitten.rs were built in Rust, Kitten.rs 
was built as a custom solution using small libraries to 
deliver a static site, whereas Lilith.rs was built using the 
Rocket and Diesel libraries. Lilith.rs was built in the 
hopes of providing a more scalable solution to my needs, 
allowing for blogs and projects to be filtered as needed 
in a database. Unfortunately, I promptly forgot to finish 
the site and began focusing on larger projects.

# Kitten.rs

Kitten.rs, on the other hand, was built as a test of if I 
could do something. I had built all of these different websites 
with large frameworks before, but didn't feel satisfied; it 
all just felt a bit too easy. So, inspired by 
YouTuber [Destiny Hailstorm](https://www.youtube.com/watch?v=6lfwcced1cM), 
I decided that I would use as little libraries as possible.
The libraries used were mainly for converting .md files to
HTML and generating the boilerplate for general HTML. 

## The Issues

*To someone whose only tool is a hammer, everything 
looks like a nail*

I did not know how to create such a system, and so
the result was a 200+ line switch statement for 
each individual page. I understand now that I 
should have instead set up a macro that registered
the page into a dictionary, enabling the system 
to simply look up the path when requested. 
Despite these flaws, this was somehow a solution 
I only discovered on the second re-write of my largest 
project [Kindred/Neeko](/projects/Kindred)

Furthermore, I wasn't too sure on the actual security 
of the system since it was reading file paths from the
url parameter. I did add code to ensure the path was 
only within one folder, but it didn't sit right 
with me. Lilith.rs had solved this problem, but 
relied on a technique that loaded in everything on 
program launch. This was a foolproof solution that I 
created for a website intended to be used by a "fool", 
but the automation often clashed how I wanted my website 
to function. 

# Kitten.rs V3

Yes, this is version 3, the second version was lost to 
development hell.

So, what makes this one different?

Upon the realisation that I actually have to get a job, 
I decided to switch my primary programming language from
Rust to C#. I already had experience with C# as it was the 
first one I learnt as a child, and I had heard the 
ecosystem had massively improved to natively support Linux;
which I had been daily driving for three years at that point.

So, taking the assets from Lilith.rs, I decided to re-write 
Lilith.rs to use Blazor and Entity Framework to replicate 
the same functionality, applying any improvements that I 
could think of since I last touched this site. As it stand, 
I have approximately 95% of the original functionality after 
four hours of work; most of which was learning how to use 
Docker. 

## Improvements 

I won't detail much on the improvements from Kitten.rs as
many were discussed in the [old Lilith.rs post](/blog/Lilith.rs). 

Following from Lilith.rs, the blog and project system uses 
a database to track each individual post. Unlike Lilith.rs 
however, this database is permanent and doesn't rely on the old 
YAML system. I don't particularly know why I thought the 
YAML system would work for me, but I felt like I was battling it 
everytime I tried to make a minor tweak to a file.  

# Future Plans

I **intend** to actually use this website like I imagined. 
In fact, I already have one active web project available at 
[yalst.kitten.rs](https://yalst.kitten.rs), discussion available 
at [YALST](/blog/yalst).

Seeing as I need to start looking for a job, I will also 
begin making the Kindred project partially public since it 
is my current peak.