var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
let RecipeEditComponent = class RecipeEditComponent {
    constructor(recipeService, router, activeRoute) {
        this.recipeService = recipeService;
        this.router = router;
        this.loaded = false;
        this.id = activeRoute.snapshot.params["id"];
    }
    ngOnInit() {
        if (this.id)
            this.recipeService.getRecipe(this.id)
                .subscribe((data) => {
                this.recipe = data;
                if (this.recipe != null) {
                    this.loaded = true;
                }
            });
    }
    save() {
        this.recipeService.updateRecipe(this.recipe.id, this.recipe)
            .subscribe(data => this.router.navigateByUrl("/"));
    }
};
RecipeEditComponent = __decorate([
    Component({
        templateUrl: './recipe-edit.component.html'
    })
], RecipeEditComponent);
export { RecipeEditComponent };
//# sourceMappingURL=recipe-edit.component.js.map