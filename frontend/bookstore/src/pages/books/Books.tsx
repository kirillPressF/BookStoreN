import Button from "antd/es/button/button"
import '../../global.css'
import { Books } from "../../components/Books"
import { useEffect, useState } from "react"
import { BookRequest, createBook, deleteBook, getAllBooks, updateBook } from "../../Services/books"
import Title from "antd/es/typography/Title"
import { Mode, CreateUpdateBook } from "../../components/CreateUpdateBook"


export default function BooksPage() {
    const defaultValues = {
        title: "",
        author: "",
        description: "",
        price: 0,
    } as Book;
    const [values, setValues] = useState<Book>({
        title: "",
        author: "",
        description: "",
        price: 0,
    } as Book);

    const [books, setBooks] = useState<Book[]>([]);
    const [loading, setLoading] = useState(true);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [mode, setMode] = useState(Mode.Create);

    useEffect(() => {
        const getBooks = async () => {
            const books = await getAllBooks();
            setLoading(false);
            setBooks(books);
        };
        getBooks();
    }, []);

    const handleCreateBook = async (request: BookRequest) => {
        await createBook(request);
        closeModal();
        const books = await getAllBooks();
        setBooks(books);
    }

    const handleUpdateBook = async (id: string, request: BookRequest) => {
        await updateBook(id, request);
        closeModal();
        const books = await getAllBooks();
        setBooks(books);
    }

    const handleDeleteBook = async (id: string) => {
        await deleteBook(id);
        closeModal();
    }

    const openModal = () => {
        setMode(Mode.Create)
        setIsModalOpen(true);
    }
    const closeModal = () => {
        setValues(defaultValues);
        setIsModalOpen(false);
    }
    const openEditModal = (book: Book) => {
        setMode(Mode.Edit);
        setValues(book);
        setIsModalOpen(true);
    };


    return (
        <div className='section'>
            <div className="row">
                <div className='row__welcome-section'>
                    <p>Please, select book in our catalog of books</p>
                </div>
            </div>
            <div className="content">
                <Button
                    type="primary"
                    style={{ marginTop: '30px' }}
                    size='large'
                    onClick={openModal}
                >
                    Add book
                </Button>
                <CreateUpdateBook
                    mode={mode}
                    values={values}
                    isModalOpen={isModalOpen}
                    handleCreate={handleCreateBook}
                    handleUpdate={handleUpdateBook}
                    handleCancel={closeModal}
                />
                {loading ? (<Title>Loading...</Title>) : <Books
                    books={books}
                    handleOpen={openEditModal}
                    handleDelete={handleDeleteBook}
                />}
            </div>
        </div>
    )
}
