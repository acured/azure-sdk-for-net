using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace FaceSDK.Tests
{
    public class SnapshotTests : BaseTests
    {
        private static readonly List<Guid> ApplyScope = new List<Guid>() { Guid.Parse("{subscriptionId1}") };

        [Fact]
        public void FaceSnapshotTestDataMigrationFaceList()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceSnapshotTestDataMigrationFaceList");

                var facelistId = Guid.NewGuid().ToString();
                var name = $"name{facelistId}";
                var userdata = $"userdata{facelistId}";

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                client.FaceList.CreateAsync(facelistId, name, userdata).Wait();

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                {
                    var persistedFace = client.FaceList.AddFaceFromStreamAsync(facelistId, stream).Result;
                    Assert.NotNull(persistedFace);
                }

                string objectType = "Facelist";
                string objectId = facelistId;
                string userContext = "user provided context data";

                var takeSnapshotResult = client.Snapshot.TakeAsync(objectType, objectId, ApplyScope, userContext).Result;
                Assert.NotNull(takeSnapshotResult.OperationLocation);

                var operationStatus = getOperationResult(client, takeSnapshotResult.OperationLocation);
                Assert.NotNull(operationStatus);
                Assert.Equal(operationStatus.Status.ToString(), OperationStatusType.Succeeded.ToString());

                var resourceId = operationStatus.ResourceLocation.Split('/').Last();

                string newFacelistId = Guid.NewGuid().ToString();
                string applyMode = "CreateNew";
                var applySnapshotResult = client.Snapshot.ApplyAsync(resourceId, newFacelistId, applyMode).Result;
                Assert.NotNull(applySnapshotResult.OperationLocation);

                operationStatus = getOperationResult(client, applySnapshotResult.OperationLocation);
                Assert.NotNull(operationStatus);
                Assert.Equal(operationStatus.Status.ToString(), OperationStatusType.Succeeded.ToString());

                var newObjectId = operationStatus.ResourceLocation.Split('/').Last();

                var newFacelist = client.FaceList.GetAsync(newObjectId).Result;
                Assert.NotNull(newFacelist);
                Assert.True(newFacelist.PersistedFaces.Count() > 0);

                client.FaceList.DeleteAsync(facelistId).Wait();
                client.FaceList.DeleteAsync(newObjectId).Wait();
                client.Snapshot.DeleteAsync(resourceId).Wait();
            }
        }

        [Fact]
        public void FaceSnapshotTestDataMigrationLargeFaceList()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceSnapshotTestDataMigrationLargeFaceList");

                var largeFacelistId = Guid.NewGuid().ToString();
                var name = $"name{largeFacelistId}";
                var userdata = $"userdata{largeFacelistId}";

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                client.LargeFaceList.CreateAsync(largeFacelistId, name, userdata).Wait();

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                {
                    var persistedFace = client.LargeFaceList.AddFaceFromStreamAsync(largeFacelistId, stream).Result;
                    Assert.NotNull(persistedFace);
                }

                var trainStatus = getTrainResult(client, largeFacelistId, "LargeFaceList");
                Assert.NotNull(trainStatus);
                Assert.Equal(trainStatus.Status.ToString(), TrainingStatusType.Succeeded.ToString());

                string objectType = "LargeFaceList";
                string objectId = largeFacelistId;
                string userContext = "user provided context data";

                var takeSnapshotResult = client.Snapshot.TakeAsync(objectType, objectId, ApplyScope, userContext).Result;
                Assert.NotNull(takeSnapshotResult.OperationLocation);

                var operationStatus = getOperationResult(client, takeSnapshotResult.OperationLocation);
                Assert.NotNull(operationStatus);
                Assert.Equal(operationStatus.Status.ToString(), OperationStatusType.Succeeded.ToString());

                var resourceId = operationStatus.ResourceLocation.Split('/').Last();

                string newLargeFacelistId = Guid.NewGuid().ToString();
                string applyMode = "CreateNew";
                var applySnapshotResult = client.Snapshot.ApplyAsync(resourceId, newLargeFacelistId, applyMode).Result;
                Assert.NotNull(applySnapshotResult.OperationLocation);

                operationStatus = getOperationResult(client, applySnapshotResult.OperationLocation);
                Assert.NotNull(operationStatus);
                Assert.Equal(operationStatus.Status.ToString(), OperationStatusType.Succeeded.ToString());

                var newObjectId = operationStatus.ResourceLocation.Split('/').Last();

                var newLargeFacelist = client.LargeFaceList.GetAsync(newObjectId).Result;
                Assert.NotNull(newLargeFacelist);

                var newLargeFacelistFaces = client.LargeFaceList.ListFacesAsync(newObjectId).Result;
                Assert.True(newLargeFacelistFaces.Count() > 0);

                client.LargeFaceList.DeleteAsync(largeFacelistId).Wait();
                client.LargeFaceList.DeleteAsync(newObjectId).Wait();
                client.Snapshot.DeleteAsync(resourceId).Wait();
            }
        }

        [Fact]
        public void FaceSnapshotTestDataMigrationPersonGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceSnapshotTestDataMigrationPersonGroup");

                var personGroupId = Guid.NewGuid().ToString();
                var name = $"name{personGroupId}";
                var userdata = $"userdata{personGroupId}";

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                client.PersonGroup.CreateAsync(personGroupId, name, userdata).Wait();

                var personName = $"personName{personGroupId.ToString()}";
                var personUserdata = $"personUserdata{personGroupId.ToString()}";
                var personGroupPersonId = client.PersonGroupPerson.CreateAsync(personGroupId, personName, personUserdata).Result.PersonId;

                Guid personGroupPersonFaceId;

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                {
                    var persistedFace = client.PersonGroupPerson.AddFaceFromStreamAsync(personGroupId, personGroupPersonId, stream).Result;
                    Assert.NotNull(persistedFace);
                    personGroupPersonFaceId = persistedFace.PersistedFaceId;
                }

                var trainStatus = getTrainResult(client, personGroupId, "PersonGroup");
                Assert.NotNull(trainStatus);
                Assert.Equal(trainStatus.Status.ToString(), TrainingStatusType.Succeeded.ToString());

                string objectType = "PersonGroup";
                string objectId = personGroupId;
                string userContext = "user provided context data";

                var takeSnapshotResult = client.Snapshot.TakeAsync(objectType, objectId, ApplyScope, userContext).Result;
                Assert.NotNull(takeSnapshotResult.OperationLocation);

                var operationStatus = getOperationResult(client, takeSnapshotResult.OperationLocation);
                Assert.NotNull(operationStatus);
                Assert.Equal(operationStatus.Status.ToString(), OperationStatusType.Succeeded.ToString());

                var resourceId = operationStatus.ResourceLocation.Split('/').Last();

                string newPersonGroupId = Guid.NewGuid().ToString();
                string applyMode = "CreateNew";
                var applySnapshotResult = client.Snapshot.ApplyAsync(resourceId, newPersonGroupId, applyMode).Result;
                Assert.NotNull(applySnapshotResult.OperationLocation);

                operationStatus = getOperationResult(client, applySnapshotResult.OperationLocation);
                Assert.NotNull(operationStatus);
                Assert.Equal(operationStatus.Status.ToString(), OperationStatusType.Succeeded.ToString());

                var newObjectId = operationStatus.ResourceLocation.Split('/').Last();

                var newPersonGroup = client.PersonGroup.GetAsync(newObjectId).Result;
                Assert.NotNull(newPersonGroup);

                var newPersonGroupPerson = client.PersonGroupPerson.GetAsync(newObjectId, personGroupPersonId).Result;
                Assert.NotNull(newPersonGroupPerson);

                var newPersonGroupPersonFace = client.PersonGroupPerson.GetFaceAsync(newObjectId, personGroupPersonId, personGroupPersonFaceId).Result;
                Assert.NotNull(newPersonGroupPersonFace);

                client.PersonGroup.DeleteAsync(personGroupId).Wait();
                client.PersonGroup.DeleteAsync(newObjectId).Wait();
                client.Snapshot.DeleteAsync(resourceId).Wait();
            }
        }

        [Fact]
        public void FaceSnapshotTestDataMigrationLargePersonGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceSnapshotTestDataMigrationLargePersonGroup");

                var largePersonGroupId = Guid.NewGuid().ToString();
                var name = $"name{largePersonGroupId}";
                var userdata = $"userdata{largePersonGroupId}";

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                client.LargePersonGroup.CreateAsync(largePersonGroupId, name, userdata).Wait();

                var personName = $"personName{largePersonGroupId}";
                var personUserdata = $"personUserdata{largePersonGroupId}";
                var largePersonGroupPersonId = client.LargePersonGroupPerson.CreateAsync(largePersonGroupId, personName, personUserdata).Result.PersonId;

                Guid largePersonGroupPersonFaceId;

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                {
                    var persistedFace = client.LargePersonGroupPerson.AddFaceFromStreamAsync(largePersonGroupId, largePersonGroupPersonId, stream).Result;
                    Assert.NotNull(persistedFace);
                    largePersonGroupPersonFaceId = persistedFace.PersistedFaceId;
                }

                var trainStatus = getTrainResult(client, largePersonGroupId, "LargePersonGroup");
                Assert.NotNull(trainStatus);
                Assert.Equal(trainStatus.Status.ToString(), TrainingStatusType.Succeeded.ToString());

                string objectType = "LargePersonGroup";
                string objectId = largePersonGroupId;
                string userContext = "user provided context data";

                var takeSnapshotResult = client.Snapshot.TakeAsync(objectType, objectId, ApplyScope, userContext).Result;
                Assert.NotNull(takeSnapshotResult.OperationLocation);

                var operationStatus = getOperationResult(client, takeSnapshotResult.OperationLocation);
                Assert.NotNull(operationStatus);
                Assert.Equal(operationStatus.Status.ToString(), OperationStatusType.Succeeded.ToString());

                var resourceId = operationStatus.ResourceLocation.Split('/').Last();

                string newLargePersonGroupId = Guid.NewGuid().ToString();
                string applyMode = "CreateNew";
                var applySnapshotResult = client.Snapshot.ApplyAsync(resourceId, newLargePersonGroupId, applyMode).Result;
                Assert.NotNull(applySnapshotResult.OperationLocation);

                operationStatus = getOperationResult(client, applySnapshotResult.OperationLocation);
                Assert.NotNull(operationStatus);
                Assert.Equal(operationStatus.Status.ToString(), OperationStatusType.Succeeded.ToString());

                var newObjectId = operationStatus.ResourceLocation.Split('/').Last();

                var newLargePersonGroup = client.LargePersonGroup.GetAsync(newObjectId).Result;
                Assert.NotNull(newLargePersonGroup);

                var newLargePersonGroupPerson = client.LargePersonGroupPerson.GetAsync(newObjectId, largePersonGroupPersonId).Result;
                Assert.NotNull(newLargePersonGroupPerson);

                var newLargePersonGroupPersonFace = client.LargePersonGroupPerson.GetFaceAsync(newObjectId, largePersonGroupPersonId, largePersonGroupPersonFaceId).Result;
                Assert.NotNull(newLargePersonGroupPersonFace);

                client.LargePersonGroup.DeleteAsync(largePersonGroupId).Wait();
                client.LargePersonGroup.DeleteAsync(newObjectId).Wait();
                client.Snapshot.DeleteAsync(resourceId).Wait();
            }
        }

        private OperationStatus getOperationResult(IFaceClient client, string operationLocation, int timeIntervalInMilliSeconds = 1000)
        {
            var operationId = string.Empty;
            if (Uri.IsWellFormedUriString(operationLocation, UriKind.RelativeOrAbsolute))
            {
                operationId = operationLocation.Split('/').Last();
            }

            var operationStatus = client.Snapshot.GetOperationStatusAsync(operationId).Result;

            while (operationStatus.Status != null
                   && !operationStatus.Status.Equals(OperationStatusType.Succeeded)
                   && !operationStatus.Status.Equals(OperationStatusType.Failed))
            {
                System.Threading.Thread.Sleep(timeIntervalInMilliSeconds);

                operationStatus = client.Snapshot.GetOperationStatusAsync(operationId).Result;
            }

            return operationStatus;
        }

        private TrainingStatus getTrainResult(IFaceClient client, string resourceId, string resourceType, int timeIntervalInMilliSeconds = 1000)
        {
            TrainingStatus trainStatus = null;

            if (resourceType == "LargeFaceList")
            {
                client.LargeFaceList.TrainAsync(resourceId).Wait();
                trainStatus = client.LargeFaceList.GetTrainingStatusAsync(resourceId).Result;
            }
            else if (resourceType == "PersonGroup")
            {
                client.PersonGroup.TrainAsync(resourceId).Wait();
                trainStatus = client.PersonGroup.GetTrainingStatusAsync(resourceId).Result;
            }
            else if (resourceType == "LargePersonGroup")
            {
                client.LargePersonGroup.TrainAsync(resourceId).Wait();
                trainStatus = client.LargePersonGroup.GetTrainingStatusAsync(resourceId).Result;
            }
            else
                return null;

            while (trainStatus != null
                   && !trainStatus.Status.Equals(TrainingStatusType.Succeeded)
                   && !trainStatus.Status.Equals(TrainingStatusType.Failed))
            {
                System.Threading.Thread.Sleep(timeIntervalInMilliSeconds);

                if (resourceType == "LargeFaceList")
                {
                    trainStatus = client.LargeFaceList.GetTrainingStatusAsync(resourceId).Result;
                }
                else if (resourceType == "PersonGroup")
                {
                    trainStatus = client.PersonGroup.GetTrainingStatusAsync(resourceId).Result;
                }
                else if (resourceType == "LargePersonGroup")
                {
                    trainStatus = client.LargePersonGroup.GetTrainingStatusAsync(resourceId).Result;
                }
            }

            return trainStatus;
        }
    }
}
