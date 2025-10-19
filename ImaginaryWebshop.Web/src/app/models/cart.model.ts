export interface CartItem {
    productId: string; 
    name: string;
    price: number; 
    quantity: number;
    pictureUrl?: string | null;
}
