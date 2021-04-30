# Azure Video Indexer to time series transformer POC

This is a POC demonstrating the possibility to extract time series data from the output of
the [Azure Video Indexer V2 Logic App Connector](https://docs.microsoft.com/en-us/connectors/videoindexer-v2/#get-video-index)
as a flat data set (a JSON array).

## Usage

Run the compiled exe with the input and output file name provided as arguments.
The input file must be the JSON output of the Azure Video Indexer service.
Refer to [this page](https://docs.microsoft.com/en-us/azure/media-services/video-indexer/video-indexer-output-json-v2#insights)
for details on the input format.

The tool will extract instances of selected insights from the first video in the file.

### Output format

The generated output is a sorted collection of all the extracted insights, with `insightType` and `insightValue` added to each instance,
where  `insightType` is the element name of the insight category ('transcript', 'labels', 'emotions', etc.) and `insightValue`
is a string containing the relevant property of the instance (eg. 'Joy', 'Sadness', etc. for an emotion).

