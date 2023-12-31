PGDMP     "                    {            IdentityProvider    15.4    15.4 9    D           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            E           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            F           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            G           1262    16398    IdentityProvider    DATABASE     �   CREATE DATABASE "IdentityProvider" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Colombia.utf8';
 "   DROP DATABASE "IdentityProvider";
                postgres    false            �            1259    32768    Action_Product    TABLE     �   CREATE TABLE public."Action_Product" (
    id_product integer NOT NULL,
    id_action integer NOT NULL,
    id_user integer NOT NULL,
    quantity integer NOT NULL,
    state character varying(10) NOT NULL,
    creation_date date NOT NULL
);
 $   DROP TABLE public."Action_Product";
       public         heap    postgres    false            �            1259    16415    Users    TABLE     �  CREATE TABLE public."Users" (
    id_user integer NOT NULL,
    email character varying(64) NOT NULL,
    name character varying(20) NOT NULL,
    last_name character varying(25) NOT NULL,
    type_document character(3) NOT NULL,
    document_number character varying(20) NOT NULL,
    creation_date date NOT NULL,
    address character varying(20) NOT NULL,
    state character varying(15) NOT NULL
);
    DROP TABLE public."Users";
       public         heap    postgres    false            �            1259    16414    Users_id_user_seq    SEQUENCE     �   CREATE SEQUENCE public."Users_id_user_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public."Users_id_user_seq";
       public          postgres    false    218            H           0    0    Users_id_user_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public."Users_id_user_seq" OWNED BY public."Users".id_user;
          public          postgres    false    217            �            1259    24576    Actions    TABLE     �   CREATE TABLE public."Actions" (
    id_action integer DEFAULT nextval('public."Users_id_user_seq"'::regclass) NOT NULL,
    type character(3) NOT NULL,
    creation_date date NOT NULL,
    description text,
    state character varying(15) NOT NULL
);
    DROP TABLE public."Actions";
       public         heap    postgres    false    217            �            1259    16407 	   InSession    TABLE     �   CREATE TABLE public."InSession" (
    id_session integer NOT NULL,
    id_user integer NOT NULL,
    "loginDate" date NOT NULL
);
    DROP TABLE public."InSession";
       public         heap    postgres    false            �            1259    16406    InSession_id_session_seq    SEQUENCE     �   CREATE SEQUENCE public."InSession_id_session_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE public."InSession_id_session_seq";
       public          postgres    false    216            I           0    0    InSession_id_session_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public."InSession_id_session_seq" OWNED BY public."InSession".id_session;
          public          postgres    false    215            �            1259    16476 	   Log_Users    TABLE     �  CREATE TABLE public."Log_Users" (
    id_log integer NOT NULL,
    id_edit_user integer NOT NULL,
    location text,
    coordinate character varying(100),
    email character varying(64),
    name character varying(20),
    last_name character varying(25),
    type_document character varying(15),
    document_number character varying(20),
    state character varying(15),
    address character varying(20),
    log_date date NOT NULL,
    description text
);
    DROP TABLE public."Log_Users";
       public         heap    postgres    false            �            1259    16475    Log_Users_id_log_seq    SEQUENCE     �   CREATE SEQUENCE public."Log_Users_id_log_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public."Log_Users_id_log_seq";
       public          postgres    false    225            J           0    0    Log_Users_id_log_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public."Log_Users_id_log_seq" OWNED BY public."Log_Users".id_log;
          public          postgres    false    224            �            1259    16467    Products    TABLE     -  CREATE TABLE public."Products" (
    id_product integer NOT NULL,
    title character varying(150) NOT NULL,
    description text,
    image text,
    price integer NOT NULL,
    creation_date date DEFAULT CURRENT_DATE NOT NULL,
    stock integer NOT NULL,
    state character varying(15) NOT NULL
);
    DROP TABLE public."Products";
       public         heap    postgres    false            �            1259    16466    Products_id_product_seq    SEQUENCE     �   CREATE SEQUENCE public."Products_id_product_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public."Products_id_product_seq";
       public          postgres    false    223            K           0    0    Products_id_product_seq    SEQUENCE OWNED BY     W   ALTER SEQUENCE public."Products_id_product_seq" OWNED BY public."Products".id_product;
          public          postgres    false    222            �            1259    16444    Rol_User    TABLE     �   CREATE TABLE public."Rol_User" (
    id_rol integer NOT NULL,
    id_user integer NOT NULL,
    state_rol character varying(15) NOT NULL,
    creation_rol date NOT NULL
);
    DROP TABLE public."Rol_User";
       public         heap    postgres    false            �            1259    16453    Roles    TABLE     �   CREATE TABLE public."Roles" (
    id_rol integer NOT NULL,
    rol_name character varying(20) NOT NULL,
    description text NOT NULL
);
    DROP TABLE public."Roles";
       public         heap    postgres    false            �            1259    16452    Roles_id_rol_seq    SEQUENCE     �   CREATE SEQUENCE public."Roles_id_rol_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public."Roles_id_rol_seq";
       public          postgres    false    221            L           0    0    Roles_id_rol_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."Roles_id_rol_seq" OWNED BY public."Roles".id_rol;
          public          postgres    false    220            �            1259    16399    SecurityPasswords    TABLE     b   CREATE TABLE public."SecurityPasswords" (
    hash bytea NOT NULL,
    password bytea NOT NULL
);
 '   DROP TABLE public."SecurityPasswords";
       public         heap    postgres    false            �           2604    16410    InSession id_session    DEFAULT     �   ALTER TABLE ONLY public."InSession" ALTER COLUMN id_session SET DEFAULT nextval('public."InSession_id_session_seq"'::regclass);
 E   ALTER TABLE public."InSession" ALTER COLUMN id_session DROP DEFAULT;
       public          postgres    false    215    216    216            �           2604    16479    Log_Users id_log    DEFAULT     x   ALTER TABLE ONLY public."Log_Users" ALTER COLUMN id_log SET DEFAULT nextval('public."Log_Users_id_log_seq"'::regclass);
 A   ALTER TABLE public."Log_Users" ALTER COLUMN id_log DROP DEFAULT;
       public          postgres    false    224    225    225            �           2604    16470    Products id_product    DEFAULT     ~   ALTER TABLE ONLY public."Products" ALTER COLUMN id_product SET DEFAULT nextval('public."Products_id_product_seq"'::regclass);
 D   ALTER TABLE public."Products" ALTER COLUMN id_product DROP DEFAULT;
       public          postgres    false    222    223    223            �           2604    16456    Roles id_rol    DEFAULT     p   ALTER TABLE ONLY public."Roles" ALTER COLUMN id_rol SET DEFAULT nextval('public."Roles_id_rol_seq"'::regclass);
 =   ALTER TABLE public."Roles" ALTER COLUMN id_rol DROP DEFAULT;
       public          postgres    false    220    221    221            �           2604    16418    Users id_user    DEFAULT     r   ALTER TABLE ONLY public."Users" ALTER COLUMN id_user SET DEFAULT nextval('public."Users_id_user_seq"'::regclass);
 >   ALTER TABLE public."Users" ALTER COLUMN id_user DROP DEFAULT;
       public          postgres    false    218    217    218            A          0    32768    Action_Product 
   TABLE DATA           j   COPY public."Action_Product" (id_product, id_action, id_user, quantity, state, creation_date) FROM stdin;
    public          postgres    false    227   ,E       @          0    24576    Actions 
   TABLE DATA           W   COPY public."Actions" (id_action, type, creation_date, description, state) FROM stdin;
    public          postgres    false    226   bE       6          0    16407 	   InSession 
   TABLE DATA           G   COPY public."InSession" (id_session, id_user, "loginDate") FROM stdin;
    public          postgres    false    216   �E       ?          0    16476 	   Log_Users 
   TABLE DATA           �   COPY public."Log_Users" (id_log, id_edit_user, location, coordinate, email, name, last_name, type_document, document_number, state, address, log_date, description) FROM stdin;
    public          postgres    false    225   �E       =          0    16467    Products 
   TABLE DATA           o   COPY public."Products" (id_product, title, description, image, price, creation_date, stock, state) FROM stdin;
    public          postgres    false    223   �F       9          0    16444    Rol_User 
   TABLE DATA           N   COPY public."Rol_User" (id_rol, id_user, state_rol, creation_rol) FROM stdin;
    public          postgres    false    219   �F       ;          0    16453    Roles 
   TABLE DATA           @   COPY public."Roles" (id_rol, rol_name, description) FROM stdin;
    public          postgres    false    221   (G       4          0    16399    SecurityPasswords 
   TABLE DATA           =   COPY public."SecurityPasswords" (hash, password) FROM stdin;
    public          postgres    false    214   cG       8          0    16415    Users 
   TABLE DATA           �   COPY public."Users" (id_user, email, name, last_name, type_document, document_number, creation_date, address, state) FROM stdin;
    public          postgres    false    218   �H       M           0    0    InSession_id_session_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."InSession_id_session_seq"', 2, true);
          public          postgres    false    215            N           0    0    Log_Users_id_log_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public."Log_Users_id_log_seq"', 2, true);
          public          postgres    false    224            O           0    0    Products_id_product_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public."Products_id_product_seq"', 4, true);
          public          postgres    false    222            P           0    0    Roles_id_rol_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Roles_id_rol_seq"', 2, true);
          public          postgres    false    220            Q           0    0    Users_id_user_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public."Users_id_user_seq"', 6, true);
          public          postgres    false    217            �           2606    24583    Actions Actions_pkey 
   CONSTRAINT     ]   ALTER TABLE ONLY public."Actions"
    ADD CONSTRAINT "Actions_pkey" PRIMARY KEY (id_action);
 B   ALTER TABLE ONLY public."Actions" DROP CONSTRAINT "Actions_pkey";
       public            postgres    false    226            �           2606    16412    InSession InSession_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public."InSession"
    ADD CONSTRAINT "InSession_pkey" PRIMARY KEY (id_session);
 F   ALTER TABLE ONLY public."InSession" DROP CONSTRAINT "InSession_pkey";
       public            postgres    false    216            �           2606    16483    Log_Users Log_Users_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public."Log_Users"
    ADD CONSTRAINT "Log_Users_pkey" PRIMARY KEY (id_log);
 F   ALTER TABLE ONLY public."Log_Users" DROP CONSTRAINT "Log_Users_pkey";
       public            postgres    false    225            �           2606    16405 &   SecurityPasswords PK_SecurityPasswords 
   CONSTRAINT     j   ALTER TABLE ONLY public."SecurityPasswords"
    ADD CONSTRAINT "PK_SecurityPasswords" PRIMARY KEY (hash);
 T   ALTER TABLE ONLY public."SecurityPasswords" DROP CONSTRAINT "PK_SecurityPasswords";
       public            postgres    false    214            �           2606    16474    Products Products_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "Products_pkey" PRIMARY KEY (id_product);
 D   ALTER TABLE ONLY public."Products" DROP CONSTRAINT "Products_pkey";
       public            postgres    false    223            �           2606    16460    Roles Roles_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Roles"
    ADD CONSTRAINT "Roles_pkey" PRIMARY KEY (id_rol);
 >   ALTER TABLE ONLY public."Roles" DROP CONSTRAINT "Roles_pkey";
       public            postgres    false    221            �           2606    16420    Users Users_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY (id_user);
 >   ALTER TABLE ONLY public."Users" DROP CONSTRAINT "Users_pkey";
       public            postgres    false    218            �           1259    16489    idx_Log_Users_id_edit_user    INDEX     \   CREATE INDEX "idx_Log_Users_id_edit_user" ON public."Log_Users" USING btree (id_edit_user);
 0   DROP INDEX public."idx_Log_Users_id_edit_user";
       public            postgres    false    225            �           2606    32776    Action_Product FK_AP_IDA    FK CONSTRAINT     �   ALTER TABLE ONLY public."Action_Product"
    ADD CONSTRAINT "FK_AP_IDA" FOREIGN KEY (id_action) REFERENCES public."Actions"(id_action) NOT VALID;
 F   ALTER TABLE ONLY public."Action_Product" DROP CONSTRAINT "FK_AP_IDA";
       public          postgres    false    227    3230    226            �           2606    32771    Action_Product FK_AP_IDP    FK CONSTRAINT     �   ALTER TABLE ONLY public."Action_Product"
    ADD CONSTRAINT "FK_AP_IDP" FOREIGN KEY (id_product) REFERENCES public."Products"(id_product);
 F   ALTER TABLE ONLY public."Action_Product" DROP CONSTRAINT "FK_AP_IDP";
       public          postgres    false    3225    223    227            �           2606    32781    Action_Product FK_AP_IDU    FK CONSTRAINT     �   ALTER TABLE ONLY public."Action_Product"
    ADD CONSTRAINT "FK_AP_IDU" FOREIGN KEY (id_user) REFERENCES public."Users"(id_user) NOT VALID;
 F   ALTER TABLE ONLY public."Action_Product" DROP CONSTRAINT "FK_AP_IDU";
       public          postgres    false    218    227    3221            �           2606    16439    InSession FK_InSession_Users    FK CONSTRAINT     �   ALTER TABLE ONLY public."InSession"
    ADD CONSTRAINT "FK_InSession_Users" FOREIGN KEY (id_user) REFERENCES public."Users"(id_user);
 J   ALTER TABLE ONLY public."InSession" DROP CONSTRAINT "FK_InSession_Users";
       public          postgres    false    218    3221    216            �           2606    16484    Log_Users FK_Log_Users_Users    FK CONSTRAINT     �   ALTER TABLE ONLY public."Log_Users"
    ADD CONSTRAINT "FK_Log_Users_Users" FOREIGN KEY (id_edit_user) REFERENCES public."Users"(id_user);
 J   ALTER TABLE ONLY public."Log_Users" DROP CONSTRAINT "FK_Log_Users_Users";
       public          postgres    false    218    3221    225            �           2606    16461    Rol_User FK_Rol_User_Roles    FK CONSTRAINT     �   ALTER TABLE ONLY public."Rol_User"
    ADD CONSTRAINT "FK_Rol_User_Roles" FOREIGN KEY (id_rol) REFERENCES public."Roles"(id_rol);
 H   ALTER TABLE ONLY public."Rol_User" DROP CONSTRAINT "FK_Rol_User_Roles";
       public          postgres    false    221    3223    219            �           2606    16447    Rol_User FK_Rol_User_Users    FK CONSTRAINT     �   ALTER TABLE ONLY public."Rol_User"
    ADD CONSTRAINT "FK_Rol_User_Users" FOREIGN KEY (id_user) REFERENCES public."Users"(id_user);
 H   ALTER TABLE ONLY public."Rol_User" DROP CONSTRAINT "FK_Rol_User_Users";
       public          postgres    false    3221    218    219            A   &   x�3�4�4��Pgg��`N##c]]#3�=... `��      @   F   x�3���S�4202�5��52�K�+IT�M����IT0�tL.�,��2��/-�TP��R�\�S���� ��      6      x�3�4�4202�5��52�2B���qqq d�~      ?   �   x�u�A�0���� �.!ą&��lƦ�	КBYp����	J�9���?O���������P�.�*GC��4���9��{25�hḮ@F2�C �+���G�}�ёe�y8��ا�lS�bg���|E�d/�D���gyyli�S���7Yf?      =   @   x�3��M����ITpL)�)�G��e�sp�X��qs:&�d��s��qqq 
��      9   0   x�3�4�tL.�,��4202�5��52�2�4�"j�i�U�	�=... �i      ;   +   x�3�tL����,.)JL�/B�qq�%&%f��L�=... r7�      4   �  x�͒ɱ0DϞ`\�Xs�b��o�,|BUH-�5����3�( �3"u�(�d�Cղ�S{ѳo�,�'ܴ��̕�c��Vͯ!��Ё�W���u2X��G�/�|�?L�V���j]�6Uv�t �"0;㣤�Y{���bS��!��˪����'�����E�Iz��;CLm$�T�v��PY�>@�M��&u$�˳��<��1P�e��[b�A�Z'ƚ�h�h;�ūvS�����dyߥ)������u��"$-�N��#HǾ� ��wDZF
�˻�VR�5��68��y���TU͛D~9� ��k��
��w�
�b����AlU�{۪��eV�Ȗm��J&c��V〼̊|*�ِ�
��6۔�H��|�~>�V��       8   �   x�3��M����uH�M���K����M�+M�����=�2/����Y����������ܐ����X��B�Ȑӵ(3;��1�$�,�ˈj&�p���(�e�dp^����0
p�d�YPT���X��H��<�!&��qqq L�X      