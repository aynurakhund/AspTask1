using Microsoft.AspNetCore.Razor.TagHelpers;
using MovieApp.Models;
using System.Text;

namespace MovieApp.TagHelpers
{
    [HtmlTargetElement("custom-table")]
    public class TableTag:TagHelper
    {
        [HtmlAttributeName("moviemodel")]

        public List<MovieModel> moviess { get; set; }=new List<MovieModel>();
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
          
            var builder = new StringBuilder();
            builder.AppendFormat(
                @"<table class='table'>
                   <thead>
                      <tr>
                         <th scope='col'>id</th>
                           <th scope='col'>name</th>
                           <th scope='col'>ImdbPoint</th>
                              <th scope='col'>directors</th>
                            <th scope='col'>Buttons</th>
                                   
                     </thead>
                     <tbody>
                                ");

            foreach(var item in moviess)
            {
                builder.AppendFormat($@"
                   <tr>
                   <td>{item.MovieId}</td>
                   <td>{item.MovieName}</td>
                   <td>{item.ImdbPoint}</td>
                   <td>{item.Director}</td>
                   <td class='d-flex flex-row gap-3'>
                        <button class='btn btn-primary'><a href='/home/EditMovie/{item.MovieId}'>Edit</a></button>
                        <button class='btn btn-danger'><a href='/home/Delete/{item.MovieId}'>Delete</a></button>
                   </td>
                   </tr>"
                   );
            }
            
            builder.AppendFormat(@"
                                 </tbody>
                                  </table>
                                 ");
            output.Content.AppendHtml(builder.ToString());
            base.Process(context, output);
        }
    }
}
