import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RecipeService } from './recipe.service';
import { Recipe } from './recipe';

@Component({
    templateUrl: './recipe-create.component.html'
})

export class RecipeCreateComponent {
    recipe: Recipe = new Recipe();

    constructor(private recipeService: RecipeService, private router: Router) { }

    save() {
        this.recipeService.createRecipe(this.recipe).subscribe(data => this.router.navigateByUrl("/"));
    }
}