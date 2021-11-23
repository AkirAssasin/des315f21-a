# DES315: Technical Design Methods

This is a research project for DES315, a module in DigiPen SG.
For my part, I am investigating on various technologies used in virtual avatar concerts.

## Six-Point Motion Capture (mocap-six)

This [Interview with COVER](https://www.youtube.com/watch?v=nARBc054hjQ) mentions that they track six points of the body in VR to perform full-body motion capture: head, waist, wrists and ankles. I decided to test this method in Unity.

As we do not have access to VR trackers, we decided to get the positions and rotations of the six points from pre-made animations, then use Unity's Animation Rigging package to perform inverse kinematics (IK).

https://user-images.githubusercontent.com/7701591/143009280-1729b046-749c-4947-9c86-80e17749b200.mp4

If we can figure out how to morph the body proportions, we can apply the tracked motion onto characters with different proportions. Here, we just crudely scaled the distance of the output IK points.

https://user-images.githubusercontent.com/7701591/143009575-2ce4269a-5bd3-442a-a446-3e000fcc0a81.mp4

The outcome is decent, but has a lot of room for improvement. For example, if we implement joint angle constraints in the IK, then we can get more accurate human poses and avoid weird and unnatural rotations.

This method is a cheaper alternative to the more costly option of using motion capture suits. This is especially important for livestreams with many performers at once, which would necessitate motion capture for each performer.

*Packages used: [Animation Rigging](https://docs.unity3d.com/Packages/com.unity.animation.rigging@latest), [Unity-chan!](https://assetstore.unity.com/packages/3d/characters/unity-chan-model-18705). VRM models made in VRoid Studio.*
