import { UserDetailsDto } from "./user.model";

export interface ProductOrderCreateDto {
    productId: string;
    quantity: number;
}

export interface ProductOrderDetailsDto {
    productId: string;
    productName: string;
    price: number;
    quantity: number;
}

export interface OrderCreateDto {
    userId: string;
    items: ProductOrderCreateDto[];
}

export interface OrderDetailsDto {
    id: string;
    orderNumber: string;
    orderDate: string;
    user: UserDetailsDto;
    amount: number;
    products: ProductOrderDetailsDto[]
}