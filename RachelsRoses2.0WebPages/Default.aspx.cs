using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RachelsRoses2._0WebPages {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void getPriceButton_Click(object sender, EventArgs e) {
            var Ingredient = ingredientTextBox.Text;
            var RecipeTitle = recipeNameTextBox.Text;
            var response
            var comment = ("The ingredient(s) for " + RecipeTitle + " are: " + Ingredient);
            getIngredientLabel.Text = comment;


            var getPriceResponse = new GetIngredientResponse(); 
            var ingredientPrice = ("The information for " + Ingredient + " is " + )
        }
    }
}