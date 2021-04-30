# ABA Therapy Cognitive App


This product has been built as a part of FSI Autism Hackathon 2021 using Microsoft Azure Services. 


## Product Description

ABA is an applied science devoted to developing procedures which will produce observable changes in behavior. Applied behaviour Analysis(ABA) Therapy is a type of therapy that can improve social,communication and learning skills. The purpose of this product is to get useful insights from video recorded therapy sessions. Parents or Therapists can use this app to Upload a therapy video and visualize the performance through the app. 

## Technical Description

### Architecture
![Architecture](Images/Architecture.png)

#### Power App (Front End)

This the UI where the user can upload recorded videos of therapy and can get the useful insights from the processed videos.

<p align="center">
  <img src="https://github.com/fsi-hack4autism/abatherapy-cognitive/blob/main/Images/app-add-new-video.jpeg">
  <img src="https://github.com/fsi-hack4autism/abatherapy-cognitive/blob/main/Images/app-existing-videos.jpeg">
</p>


<p align="center">
  <img src="https://github.com/fsi-hack4autism/abatherapy-cognitive/blob/main/Images/app-review-video.jpeg">
</p>


#### Containers

The uploaded video is going to stored in the input container of the Azure Cloud.
![Container](Images/Containers.JPG)

#### Logic App # 1 - Video Indexer

Once the new video is uploaded the video indexer gets triggered and video gets processsed.
![Logic App1](Images/LogicApp1.JPG)

#### Logic App # 2

Gets triggered once the video is indexed and Uploads the JSON generated from indexer to output container.
![Logic App2](Images/LogicApp2.JPG)
[More Info](https://docs.microsoft.com/en-us/azure/media-services/video-indexer/logic-apps-connector-tutorial)

#### Cosmos DB

It is a storage solution for storing unstructured data like the output JSON.

#### Power BI

It is a Business Analytics Service used for getting useful insights from the processed data.

## Contribution

Any contributor is very welcome to contribute in this initiative.


## Future Scope
1. Have a way to visually track expected behavior of the patient vs actual behavior displayed by looking into the patient's emotions and sentiments over a timeline. This would give the parents and therapist a view of how the therapy sessions are progressing.
2. Ability to review and add comments by therapists.
3. Increase the allowed size of uploaded videos from 100MB.
4. Display captured insights alongside video playback. Ability to add custom insights using on-screen clickers.
5. Enhancing the video viewing experience so that it is streamed rather then downloaded to local storage.
6. Dynamically refresh power BI datasets whenever there is an update to the Cosmos DB.
