import { Component, OnInit, Input, EventEmitter, Output } from "@angular/core";
import { Item } from "../core/models/item";
import { ItemActionEnum } from "../core/enums/item-action.enum";

@Component({
  selector: "app-item-details",
  templateUrl: "./item-details.component.html",
  styleUrls: ["./item-details.component.css"]
})
export class ItemDetailsComponent implements OnInit {
  title: string;
  btnText: string;
  @Input() item: Item;

  @Input() itemAction: ItemActionEnum;
  @Input() loading: boolean;

  @Output() action = new EventEmitter<Item>();

  constructor() {
    if (!this.item) {
      this.item = new Item();
    }
  }

  ngOnInit() {
    this.setTitleAndBtnText(this.itemAction);
  }

  setTitleAndBtnText(itemAction: ItemActionEnum) {
    switch (itemAction) {
      case ItemActionEnum.Add:
        this.title = "Add Item";
        this.btnText = "Add";
        break;
      case ItemActionEnum.Update:
        this.title = "Update Item";
        this.btnText = "Update";
        break;
      default:
        this.title = "Add Item";
        this.btnText = "Add";
    }
  }

  clickBtn() {
    this.action.emit(this.item);
  }
}
