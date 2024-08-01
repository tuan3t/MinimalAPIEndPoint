using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandHandlers
{
    internal class CreatePostHandler : IRequestHandler<CreatePost, Post>
    {
        private readonly IPostRepository _postsRepo;

        public CreatePostHandler(IPostRepository postRepo)
        {
            _postsRepo = postRepo;
        }

        public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
        {
            var newPost = new Post
            {
                Content = request.PostContent
            };

            return await _postsRepo.CreatePost(newPost);
        }
    }
}
