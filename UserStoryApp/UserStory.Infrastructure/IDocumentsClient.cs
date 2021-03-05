namespace UserStoryStuff
{
    public interface IDocumentsClient
    {
        string BaseUrl { get; set; }
        bool ReadResponseAsString { get; set; }

        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<NewRecordResponse> AddDocumentAsync(AddDocumentCommand command);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<NewRecordResponse> AddDocumentAsync(AddDocumentCommand command, System.Threading.CancellationToken cancellationToken);

        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<Response> EditDocumentAsync(UpdateDocumentCommand command);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<Response> EditDocumentAsync(UpdateDocumentCommand command, System.Threading.CancellationToken cancellationToken);

        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<StoreDocumentResponse> StoreDocumentAsync(StoreDocumentCommand command);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<StoreDocumentResponse> StoreDocumentAsync(StoreDocumentCommand command, System.Threading.CancellationToken cancellationToken);

        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<Response> DeleteDocumentAsync(DeleteDocumentCommand command);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<Response> DeleteDocumentAsync(DeleteDocumentCommand command, System.Threading.CancellationToken cancellationToken);

        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<GetDocumentsResponse> GetDocumentsByCollectionAsync(GetDocumentsByCollection query);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<GetDocumentsResponse> GetDocumentsByCollectionAsync(GetDocumentsByCollection query, System.Threading.CancellationToken cancellationToken);

        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<GetDocumentResponse> GetDocumentAsync(GetDocumentQuery query);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<GetDocumentResponse> GetDocumentAsync(GetDocumentQuery query, System.Threading.CancellationToken cancellationToken);
    }
}