# spaceinvaders01

<p>Basic rereation of the original Space Invaders in C#/MonoGame.</p>
<p>
<img src=https://github.com/defaultroot1/spaceinvaders01/blob/master/spaceInvadersScreenshot.png>
</p>
<p>After making Breakout I thought this would be very straightforward, after all on paper it's just Breakout with lasers! But there were a few complexities I didn't account for until I got coding, and ran into a few bugs that delayed things.</p>
<p>I had the game 90% complete with static sprites before deciding to animate the aliens. This turned out to be a big mistake! I was using Texture.Width/Height for a lot of calculations so the introduction of a spritesheet resulted in a lot of subtle bugs and refactoring. I thought it would have been relatively easy to go from static sprites to animated, and that it would be common in the game dev process to use static sprites as a placeholder before replacing with animation. That might still be the case, but it's definitely something that needs to be planned. Lesson learnt.</p>
<p>I'm very happy with the alien swarm; realising that aliens only fire when there's no alien in front of them had me worried, but I was surprised by how quickly I had that coded. Same for the destructible bunkers, which were fun to code.</p>
<p>There's a lot of messy stuff, some horrible hardcoded numbers, inheritance was badly planned and caused a lot of frustration, and I still struggle to decide what the best approach is between using public static classes or instances being passed around. But this was a very good learning experience to code from scratch.</p>